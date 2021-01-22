using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static ElectronicShopBL.Helper.helper;

namespace ElectronicShop.Filters
{
    public class AuthorizeAdmin: ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            var session = context.HttpContext.Session;
            byte[] value;
            if (!session.IsAvailable)
                Unauthorized(context);
            session.TryGetValue("UserRole", out value);
            if (value == null)
            {
                Login(context);
            }
            else
            {
                int userRole = value[0];
                if (userRole != (int)Roles.Admin)
                {
                    Unauthorized(context);
                }

            }
            base.OnActionExecuting(context);
        }
        private IActionResult Unauthorized(ActionExecutingContext context)
        {
            return context.Result = new ContentResult()
            {
                Content = "Unauthorized to access specified resource.",
                StatusCode = StatusCodes.Status401Unauthorized
            };
        }
        private IActionResult Login(ActionExecutingContext context)
        {

            return context.Result = new RedirectToActionResult("Login", "User", null);

        }
    }
}
