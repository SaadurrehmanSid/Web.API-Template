using MediatR;
using MediatR.Wrappers;
using Microsoft.EntityFrameworkCore;
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
using Web.API.Core.DTOs.Base;
using Web.API.Infrastructure.SqlRepositories;

namespace Web.API.Application.Features.PublicHoliday.Queries
{
    //TODO : we need to add pagination for this
    public class GetAllPublicHolidaysQuery :IRequest<ApplicationResult<List<PublicHolidayResponseDto>>>
    {
    }

    public class GetAllPublicHolidaysHandler : RequestHandlerBase<GetAllPublicHolidaysQuery, ApplicationResult<List<PublicHolidayResponseDto>>>
    {
        private IPublicHolidayRepository _publicHolidayRepository;

        public GetAllPublicHolidaysHandler(IServiceProvider serviceProvider, 
            ILogger<GetAllPublicHolidaysHandler> logger,
            IPublicHolidayRepository publicHolidayRepository) : base(serviceProvider,logger)
        {
            _publicHolidayRepository = publicHolidayRepository;
        }

        protected override  async Task<ApplicationResult<List<PublicHolidayResponseDto>>> HandleRequest(GetAllPublicHolidaysQuery request, CancellationToken cancellationToken)
        {
            var query = _publicHolidayRepository.Get();
            int totalCount = query.Count();
            return ApplicationResult<List<PublicHolidayResponseDto>>.SuccessResult(_mapper.Map<List<PublicHolidayResponseDto>>( await query.ToListAsync()),totalCount);
        }
    }
}
