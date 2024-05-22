using MediatR;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Web.API.Application.Common.ApplicationResponseModel;
using Web.API.Application.Features.PublicHoliday.Commands;
using Web.API.Application.Features.PublicHoliday.DTOs;
using Web.API.Application.Features.PublicHoliday.Queries;

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
            var result = await _mediator.Send(command);
            return result;

        }


        [HttpPut]
        public async Task<ApplicationResult<Guid>> UpdatePublicHoliday(UpdatePublicHolidayCommand command)
        {
            return await _mediator.Send(command);
        }

        [HttpDelete]
        public async Task<ApplicationResult<Guid>> DeletePublicHoliday(DeletePublicHolidayCommand command)
        {
            return await _mediator.Send(command);
        }

        [HttpGet]
        public async Task<ApplicationResult<PublicHolidayResponseDto>> GetPublicHoliday([FromQuery] GetPublicHolidayQuery query)
        {
            return await _mediator.Send(query);
        }

        [HttpGet("GetAllPublicHolidays")]
        public async Task<ApplicationResult<List<PublicHolidayResponseDto>>> GetAll([FromQuery]GetAllPublicHolidaysQuery query) 
        {
            return await _mediator.Send(query);
        }


    }
}
