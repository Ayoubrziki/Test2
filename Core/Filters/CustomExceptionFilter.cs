using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Serilog;
using Domain.Exception;

namespace Core.Filters
{
    public class CustomExceptionFilter : IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
            Logger.Error(context.Exception, context.Exception.Message);

            var errorModel = new ErrorViewModel
            {
                ErrorCode = 500,
                ErrorMessage = context.Exception.Message,
                StackTrace = context.Exception.StackTrace
            };

            context.Result = new RedirectToActionResult("Error","Flight", errorModel);

            context.ExceptionHandled = true;
        }
    }
}
