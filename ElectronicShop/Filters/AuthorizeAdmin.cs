using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ElectronicShop.Filters
{
    public class AuthorizeAdmin: ActionFilterAttribute
    {
        public override void OnActionExecuted(ActionExecutedContext context)
        {
            var session = context.HttpContext.Session;
            byte[] value;
            if (!session.IsAvailable)
                Unauthorized(context);
            if (!session.TryGetValue("UserRole", out  value))
            {
                Unauthorized(context);
            }
            base.OnActionExecuted(context);
        }
        private IActionResult Unauthorized(ActionExecutedContext context)
        {
            return context.Result = new ContentResult()
            {
                Content = "Unauthorized to access specified resource.",
                StatusCode = StatusCodes.Status401Unauthorized
            };
        }
    }
}
