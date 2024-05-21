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
using Web.API.Core.Domain.Entities;

namespace Web.API.Application.Features.PublicHoliday.Commands
{
    public class CreatePublicHolidayCommand : IRequest<ApplicationResult<Guid>>
    {
        public int? SequenceNo { get; set; }

        [Required]
        public DateTime TransactionDate { get; set; }

        [Required]
        [MaxLength(100)]
        public string Explanation { get; set; }

        public short? TypeNo { get; set; } = 0;
    }

    public class CreatePublicHolidayHandler : RequestHandlerBase<CreatePublicHolidayCommand, ApplicationResult<Guid>>
    {
        private IPublicHolidayRepository _publicHolidayRepository;

        public CreatePublicHolidayHandler(IServiceProvider serviceProvider,
            ILogger<CreatePublicHolidayHandler> logger,
            IPublicHolidayRepository publicHolidayRepository) :base(serviceProvider, logger)
        {
            _publicHolidayRepository = publicHolidayRepository;
        }
        protected override async Task<ApplicationResult<Guid>> HandleRequest(CreatePublicHolidayCommand request, CancellationToken cancellationToken)
        {
            var publicHoliday = new Web.API.Core.Domain.Entities.PublicHoliday()
            {
                SequenceNo = request.SequenceNo,
                TransactionDate = request.TransactionDate,
                Explanation = request.Explanation,
                TypeNo = request.TypeNo,
                IsActive = true,
                CreatedDate = DateTime.UtcNow,

            };

            var result = await _publicHolidayRepository.AddAsync(publicHoliday);
            return ApplicationResult<Guid>.SuccessResult(result.Id);
        }
    }
}
