using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.AspNetCore.Mvc;
using Shopping_Store_API.Entities;
using Shopping_Store_API.Commons;
using System.ComponentModel;

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

            // Get the enum member
            var enumMember = typeof(Commons.ErrorCodes).GetMember(apiError.ErrorName.ToString())[0];

            // Access the Description property
            var description = enumMember.CustomAttributes.FirstOrDefault().NamedArguments.FirstOrDefault().TypedValue.Value.ToString();

            // always return a JSON result
            context.Result = new JsonResult(new
            {
                apiError.ErrorCode,
                apiError.ErrorName,
                errorMessage = description,
            });

            base.OnException(context);
        }
    }
}
