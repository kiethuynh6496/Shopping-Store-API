using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.AspNetCore.Mvc;
using Shopping_Store_API.Entities;

namespace Shopping_Store_API.Filters
{
    public class ApiExceptionFilter : ExceptionFilterAttribute
    {
        public override void OnException(ExceptionContext context)
        {
            ApiError apiError;

            // handle explicit 'known' API errors
            if (context.Exception is ApiError)
            {
                apiError = context.Exception as ApiError;
                context.Exception = null;

                context.HttpContext.Response.StatusCode = 502;
            }
            else
            {
                // Unhandled errors
                apiError = new ApiError((int)Commons.ErrorCodes.OopsSomethingHapped)
                {
                    ErrorMessage = "An unhandled error occurred.",
                };

                context.HttpContext.Response.StatusCode = 500;
            }

            // always return a JSON result
            context.Result = new JsonResult(new
            {
                apiError.ErrorCode,
                apiError.ErrorName,
                errorMessage = context.Exception?.Message,
            });

            base.OnException(context);
        }
    }
}
