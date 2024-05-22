using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Web.API.Application.Common;
using Web.API.Application.Common.ApplicationResponseModel;
using Web.API.Core.Domain.Interfaces.Repositories;
using Web.API.Infrastructure.SqlRepositories;

namespace Web.API.Application.Features.PublicHoliday.Commands
{
    public class UpdatePublicHolidayCommand : IRequest<ApplicationResult<Guid>>
    {
        public Guid Id { get; set; }
        public int? SequenceNo { get; set; }

        [Required]
        public DateTime TransactionDate { get; set; }

        [Required]
        [MaxLength(100)]
        public string Explanation { get; set; }

        public short? TypeNo { get; set; } = 0;
    }


    public class UpdatePublicHolidayHandler : RequestHandlerBase<UpdatePublicHolidayCommand, ApplicationResult<Guid>>
    {
        private IPublicHolidayRepository _publicHolidayRepository;

        public UpdatePublicHolidayHandler(IServiceProvider serviceProvider,
            ILogger<UpdatePublicHolidayHandler> logger,
            IPublicHolidayRepository publicHolidayRepository): base(serviceProvider,logger)
        {
            _publicHolidayRepository = publicHolidayRepository;
        }
        protected override async Task<ApplicationResult<Guid>> HandleRequest(UpdatePublicHolidayCommand request, CancellationToken cancellationToken)
        {
           var publicHoliday = await _publicHolidayRepository.GetByIdAsync(request.Id);
            if (publicHoliday is null)
            {
                return ApplicationResult<Guid>.Error("Public Holiday not found");
            }
            publicHoliday.SequenceNo = request.SequenceNo;
            publicHoliday.TransactionDate = request.TransactionDate;
            publicHoliday.Explanation = request.Explanation;
            publicHoliday.TypeNo = request.TypeNo;

             await _publicHolidayRepository.UpdateAsync(publicHoliday);
            return ApplicationResult<Guid>.SuccessResult(publicHoliday.Id);
        }
    }
}
