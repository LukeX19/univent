using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Univent.Api.Contracts.Error;

namespace Univent.Api.Filters
{
    public class ValidateModelAttribute : ActionFilterAttribute
    {
        public override void OnResultExecuting(ResultExecutingContext context)
        {
            if(!context.ModelState.IsValid)
            {
                var apiError = new ErrorResponse();
                apiError.StatusCode = 400;
                apiError.StatusMessage = "Bad Request";
                apiError.Timestamp = DateTime.Now;

                var errors = context.ModelState.AsEnumerable();

                foreach (var error in errors)
                {
                    foreach (var inner in error.Value.Errors)
                    {
                        apiError.Errors.Add(inner.ErrorMessage);
                    }
                }

                context.Result = new BadRequestObjectResult(apiError);
                //TO DO: find a way to make sure that ASP.NET Core does
                //not override our action result body
            }
        }
    }
}
