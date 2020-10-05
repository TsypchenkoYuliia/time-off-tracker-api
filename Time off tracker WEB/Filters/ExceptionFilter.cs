using System;
using Microsoft.AspNetCore.Mvc.Filters;

namespace TimeOffTracker.WebApi.Filters
{
    public class ExceptionFilter : ExceptionFilterAttribute
    {
        public override void OnException(ExceptionContext context) 
        {
            throw new NotImplementedException();
        }
    }
}
