using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Web.API.Application.Common.ApplicationResponseModel.ResponseComponents;
using Web.API.Application.Common.Context.Models;

namespace Web.API.Application.Common.Helpers
{
    public interface IExceptionHelper
    {
        Task<ErrorResponse> GetErrorResponse(Exception ex, CurrentUserContext currentUser, bool sendEmail = false, string? customMessage = null, bool logToDb = true);
        Task<Guid> Log(Exception e, CurrentUserContext currentUser, bool sendEmail = false);
    }
}
