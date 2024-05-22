using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Web.API.Application.Features.PublicHoliday.Commands;

namespace Web.API.Application.Features.PublicHoliday.Validators
{
    public class CreatePublicHolidayCommandValidator : AbstractValidator<CreatePublicHolidayCommand>
    {
        public CreatePublicHolidayCommandValidator() {
            RuleFor(x => x.SequenceNo).NotEmpty().WithMessage("Sequence Number Cannot be empty!");
        }
    }
}
