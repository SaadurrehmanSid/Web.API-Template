using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Web.API.Application.Common.ApplicationResponseModel.ResponseComponents;
using Web.API.Application.Common.Context.Models;
using Web.API.Application.Common.Enums;
using Web.API.Core.Domain.Entities;
using Web.API.Infrastructure.Data.DAL;

namespace Web.API.Application.Common.Helpers
{
    public class ExceptionHelper : IExceptionHelper
    {

        public ExceptionHelper(
          //IEmailSenderService emailHandler,
          AppDbContext dbContext,
          ILogger<ExceptionHelper> logger,
          IConfiguration configuration/* IHostingEnvironment hostingEnvironment*/
          )
        {
            _configuration = configuration;
            //_emailHandler = emailHandler;
            _dbContext = dbContext;
            _logger = logger;
            //_hostingEnvironment = hostingEnvironment;

        }


        //private readonly IHostingEnvironment _hostingEnvironment;
        //private readonly IEmailSenderService _emailHandler;
        private readonly AppDbContext _dbContext;
        private readonly ILogger<ExceptionHelper> _logger;

        private IConfiguration _configuration { get; }

        public async Task<ErrorResponse> GetErrorResponse(Exception ex, CurrentUserContext currentUser, bool sendEmail = false, string? customMessage = null!, bool logToDb = true)
        {
           
            if (logToDb)
            {
               await Log(ex, currentUser, sendEmail: sendEmail);
            }

            string errorMessage;
            //if no custom message then add the error log //  in case of Exception type
            if (string.IsNullOrWhiteSpace(customMessage))
            {
                errorMessage = $"Something went wrong on the server, Please reach out to support and refer to this errorId: {(long)ErrorEnums.SomethingWentWrong}";
            }
            else //else add the custom message
            {
                errorMessage = customMessage;
            }

            return new ErrorResponse { Errors = new List<string> { errorMessage }, IsSuccess = false };
        }

        //[Obsolete]
        public async Task<Guid> Log(Exception e, CurrentUserContext currentUser, bool sendEmail = false)
        {
            var Description = string.Empty;

            if (!string.IsNullOrEmpty(Convert.ToString(e.InnerException)))
            {
                Description = " InnerException: " + e.InnerException;
            }
            if (!string.IsNullOrEmpty(Convert.ToString(e.Message)))
            {
                if (!string.IsNullOrEmpty(Description))
                {
                    Description += Environment.NewLine;
                }
                Description += " Message: " + e.Message;
            }
            if (!string.IsNullOrEmpty(Convert.ToString(e.StackTrace)))
            {
                if (!string.IsNullOrEmpty(Description))
                {
                    Description += Environment.NewLine;
                }
                Description += " StackTrace: " + e.StackTrace;
            }
            _logger.LogError(Description);

            // logging class example
            ExceptionLogs log = new ExceptionLogs
            {
                
                // ProjectId = we need to get it form claims 
                //Request  = api url maybe
                //Controller i need to check if we can get this form exception
                IsSolved = false,
                
                Exception = Description,
                // TODO we need to get tenantId and pass here!
                //TenantId = we need to get this form claims,
            };

         
            _dbContext.ExceptionLogs.Add(log);
            await _dbContext.SaveChangesAsync();

            //Sending Email if we want to send email on ecxecption || send exception to your self on exception
            //if (sendEmail && _configuration.GetValue<bool>("EmailConfiguration:SendMail"))
            //{
            //    var emailSubject = "Error occurred on the project";
            //    var emailContent = $"Dear Admin ,<br/><br/>{Description}<br/><br/>Regards <br/>Support Team";

              
            //    //await _emailHandler.SendEmailAsync("z.adil@routd.com", emailSubject, emailContent, "");
            //}
            return log.Id;
        }
    }
}
