using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Web.API.Application.Common;
using Web.API.Application.Common.ApplicationResponseModel;
using Web.API.Core.Domain.Interfaces.Repositories;
using Web.API.Infrastructure.SqlRepositories;

namespace Web.API.Application.Features.PublicHoliday.Commands
{
    public class DeletePublicHolidayCommand : IRequest<ApplicationResult<Guid>>
    {
        public Guid Id { get; set; }
    }

    public class DeletePublicHolidayHandler : RequestHandlerBase<DeletePublicHolidayCommand, ApplicationResult<Guid>>
    {
        private IPublicHolidayRepository _publicHolidayRepository;

        public DeletePublicHolidayHandler(IServiceProvider serviceProvider,
            ILogger<DeletePublicHolidayHandler> logger,
            IPublicHolidayRepository publicHolidayRepository):base(serviceProvider,logger)
        {
            _publicHolidayRepository = publicHolidayRepository;
        }

        protected override async Task<ApplicationResult<Guid>> HandleRequest(DeletePublicHolidayCommand request, CancellationToken cancellationToken)
        {
            var publicHoliday = await _publicHolidayRepository.GetByIdAsync(request.Id);
            if (publicHoliday == null)
            {
                return ApplicationResult<Guid>.Error("Public Holiday not found");
            }
            await _publicHolidayRepository.DeleteAsync(request.Id);
            return ApplicationResult<Guid>.SuccessResult(request.Id);
        }
    }
}
