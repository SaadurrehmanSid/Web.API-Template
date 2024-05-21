using MediatR;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Web.API.Application.Common.ApplicationResponseModel;
using Web.API.Application.Features.PublicHoliday.Commands;

namespace Web.API.EndPoints
{
    [Route("[controller]")]
    [ApiController]
    public class PublicHolidayController : ControllerBase
    {
        private IMediator _mediator;
        public PublicHolidayController(IMediator mediator)
        {
            _mediator = mediator; 
        }

        [HttpPost(Name = "CreatePublicHoliday")]
        public async Task<ApplicationResult<Guid>> Create([FromForm] CreatePublicHolidayCommand command)
        {
            return await _mediator.Send(command);
        }
    }
}
