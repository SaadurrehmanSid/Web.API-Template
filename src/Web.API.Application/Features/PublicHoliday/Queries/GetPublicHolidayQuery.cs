using MediatR;
using MediatR.Wrappers;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Web.API.Application.Common;
using Web.API.Application.Common.ApplicationResponseModel;
using Web.API.Application.Features.PublicHoliday.DTOs;
using Web.API.Core.Domain.Interfaces.Repositories;
using Web.API.Infrastructure.SqlRepositories;

namespace Web.API.Application.Features.PublicHoliday.Queries
{
    public class GetPublicHolidayQuery : IRequest<ApplicationResult<PublicHolidayResponseDto>>
    {
        public Guid Id { get; set; }
    }

    public class GetPublicHolidayQueryHandler : RequestHandlerBase<GetPublicHolidayQuery, ApplicationResult<PublicHolidayResponseDto>>
    {
        private IPublicHolidayRepository _publicHolidayRepository;

        public GetPublicHolidayQueryHandler(IServiceProvider serviceProvider,
            ILogger<GetPublicHolidayQueryHandler> logger,
            IPublicHolidayRepository publicHolidayRepository) : base(serviceProvider,logger)
        {
            _publicHolidayRepository = publicHolidayRepository;
        }

        protected override async Task<ApplicationResult<PublicHolidayResponseDto>> HandleRequest(GetPublicHolidayQuery request, CancellationToken cancellationToken)
        {
            var publicHoliday = await _publicHolidayRepository.GetByIdAsync(request.Id);
            if (publicHoliday == null)
            {
                return ApplicationResult<PublicHolidayResponseDto>.Error("Public Holiday not found");
            }

            return ApplicationResult<PublicHolidayResponseDto>.SuccessResult(_mapper.Map<PublicHolidayResponseDto>(publicHoliday));
        }
    }
}
