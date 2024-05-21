using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Web.API.Application.Common.ApplicationResponseModel.Interface;

namespace Web.API.Application.Common.ApplicationResponseModel.ResponseComponents
{
    public class ErrorResponse : IErrorResponse
    {
        public ErrorResponse()
        {
            Errors = new List<string>();
            ValidationErrors = new List<ValidationError>();
            IsSuccess = true;
        }
        public bool IsSuccess { get; set; }
        public IEnumerable<string> Errors { get; set; }
        public IEnumerable<ValidationError> ValidationErrors { get; set; }
        public string? Message { get; set; }
    }
}
