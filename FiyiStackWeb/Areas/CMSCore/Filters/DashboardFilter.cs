using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;

namespace FiyiStackWeb.Filters
{
    public class DashboardFilter : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
        }

        public override void OnActionExecuted(ActionExecutedContext context)
        {
        }
        public override void OnResultExecuting(ResultExecutingContext context)
        {
            int? UserId = context.HttpContext.Session.GetInt32("UserId");
            if (UserId == null || UserId == 0)
            {
                context.HttpContext.Response.Redirect("/BasicCore/Error?ErrorId=401");
            }
        }

        public override void OnResultExecuted(ResultExecutedContext context)
        {
        }
    }
}