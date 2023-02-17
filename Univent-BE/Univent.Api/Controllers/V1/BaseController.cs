using Microsoft.AspNetCore.Mvc;
using Univent.Api.Contracts.Error;
using Univent.Application.Enums;
using Univent.Application.Models;

namespace Univent.Api.Controllers.V1
{
    public class BaseController : ControllerBase
    {
        protected IActionResult HandleErrorResponse(List<Error> errors)
        {
            var apiError = new ErrorResponse();

            if(errors.Any(e => e.Code == ErrorCodeEnum.NotFound))
            {
                var error = errors.FirstOrDefault(e => e.Code == ErrorCodeEnum.NotFound);
                
                apiError.StatusCode = 404;
                apiError.StatusMessage = "Not Found";
                apiError.Errors.Add(error.Message);
                apiError.Timestamp = DateTime.Now;

                return NotFound(apiError);
            }

            apiError.StatusCode = 500;
            apiError.StatusMessage = "Internal Server Error";
            apiError.Errors.Add("Unknown Error");
            apiError.Timestamp = DateTime.Now;
            return StatusCode(500, apiError);
        }
    }
}
