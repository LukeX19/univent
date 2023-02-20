using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Univent.Api.Contracts.Error;

namespace Univent.Api.Filters
{
    public class ValidateModelAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            if(!context.ModelState.IsValid)
            {
                var apiError = new ErrorResponse();
                apiError.StatusCode = 400;
                apiError.StatusMessage = "Bad Request";
                
                var errors = context.ModelState.AsEnumerable();

                foreach (var error in errors)
                {
                    apiError.Errors.Add(error.Value.ToString());
                }

                apiError.Timestamp = DateTime.Now;

                context.Result = new JsonResult(apiError) { StatusCode = 400 };
                //TO DO: find a way to make sure that ASP.NET Core does
                //not override our action result body
            }
        }
    }
}
