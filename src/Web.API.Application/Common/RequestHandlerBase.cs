using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Web.API.Application.Common.ApplicationResponseModel.Interface;
using Web.API.Application.Common.ApplicationResponseModel.ResponseComponents;
using Web.API.Application.Common.Context.Models;
using Web.API.Application.Common.Exceptions;
using Web.API.Application.Common.Helpers;

namespace Web.API.Application.Common
{
    public abstract class RequestHandlerBase
    {

        protected readonly IServiceProvider _serviceProvider;
        /// <summary>
        /// Gets the mapper.
        /// </summary>
        /// <value>
        /// The mapper.
        /// </value>
        protected IMapper _mapper;
        protected IExceptionHelper _exceptionHelper;
        protected IHttpContextAccessor _httpContextAccessor;

        protected ILogger Logger { get; }


        protected ClaimsIdentity? _identity;
        public IEnumerable<Claim>? _claims { get; }
        protected CurrentUserContext _currentUser = new CurrentUserContext();


        protected RequestHandlerBase(IServiceProvider serviceProvider, ILogger logger)
        {
            _serviceProvider = serviceProvider;
            Logger = logger;
            _mapper = _serviceProvider.GetRequiredService<IMapper>();
            _exceptionHelper = _serviceProvider.GetRequiredService<IExceptionHelper>();
            _httpContextAccessor = _serviceProvider.GetRequiredService<IHttpContextAccessor>();

            _identity = _httpContextAccessor.HttpContext?.User.Identity as ClaimsIdentity;
            _claims = _identity!.Claims;

            // we need to create these claims
            //_currentUser.Id = Convert.ToInt64(_claims?.FirstOrDefault(x => x.Type == IdentityConstants.UserIdClaim)?.Value);
            //_currentUser.ClientGroupId = Convert.ToInt64(_claims?.FirstOrDefault(x => x.Type == IdentityConstants.ClientGroupClaim)?.Value);
            //_currentUser.SubscriptionTypeId = Convert.ToInt64(_claims?.FirstOrDefault(x => x.Type == IdentityConstants.SubscriptionTypeClaim)?.Value);
            //_currentUser.SubscriptionPriceId = Convert.ToInt64(_claims?.FirstOrDefault(x => x.Type == IdentityConstants.SubscriptionPriceClaim)?.Value);

            //_currentUser.ClientId = Convert.ToInt64(_claims?.FirstOrDefault(x => x.Type == IdentityConstants.ClientClaim)?.Value);

            _currentUser.UserName = _claims?.FirstOrDefault(x => x.Type == ClaimTypes.Email)?.Value;

            foreach (var item in _claims!.Where(x => x.Type == ClaimTypes.Role).Select(x => x.Value).ToList())
            {
                var role = item;
                _currentUser.NotMappedRoles.Add(role);
            }



        }


        protected async Task<TResponseType> RunAsync<TRequestType, TResponseType>(Func<Task<TResponseType>> action) where TResponseType : IErrorResponse, new()
        {

            var result = new TResponseType();

            try
            {

                var requestType = $"{typeof(TRequestType).ToString() ?? "null"}";
                Logger.LogTrace("Processing request '{requestType}'", requestType);
                result = await action();
                return result;
            }
            catch (Exception ex)
            {
                Logger.LogError(ex, ex.Message, ex.StackTrace);

                ErrorResponse response = new();


                if (ex is PdksApplicationException || ex is NotSupportedException)
                {
                    response = await _exceptionHelper.GetErrorResponse(ex, _currentUser, sendEmail: false, customMessage: ex.Message, logToDb: true);
                }
                else
                {

                    Logger.LogError($"{_currentUser.ClientId} {ex.Message} {ex.InnerException} {ex.StackTrace}");

                    response = await _exceptionHelper.GetErrorResponse(ex, _currentUser, sendEmail: true);
                }

                result.IsSuccess = false;
                result.Errors = response.Errors;

                return result;
            }
        }
    }

    /// <summary>
    /// Middleware for processing MediatR commands.
    /// </summary>
    /// <typeparam name="TRequest">The type of the request.</typeparam>
    /// <typeparam name="TResponse">The type of the response.</typeparam>
    /// <seealso cref="MediatR.IRequestHandler{TRequest, TResponse}" />
    public abstract class RequestHandlerBase<TRequest, TResponse> : RequestHandlerBase, IRequestHandler<TRequest, TResponse>
        where TRequest : IRequest<TResponse> where TResponse : IErrorResponse, new()
    {
        //protected ClaimsIdentity? _identity;
        //public IEnumerable<Claim>? _claims { get; }
        protected CurrentUserContext _currentUser = new CurrentUserContext();
        //public const string UserId = "UserId";

        protected RequestHandlerBase(IServiceProvider serviceProvider, ILogger logger) : base(serviceProvider, logger)
        {
         
        }

        public async Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken)
        {
            if (request == null)
                throw new PdksApplicationException(System.Net.HttpStatusCode.BadRequest,
                    $"{typeof(TRequest)} was null.",
                    new ArgumentNullException(typeof(TRequest).ToString()));

            var result = await RunAsync<TRequest, TResponse>(async () => await HandleRequest(request, cancellationToken));
            return result;
        }

        /// <summary>
        /// Handles the request.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns></returns>
        protected abstract Task<TResponse> HandleRequest(TRequest request, CancellationToken cancellationToken);
    }

}
