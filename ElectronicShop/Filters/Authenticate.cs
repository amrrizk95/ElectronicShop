using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Routing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static ElectronicShopBL.Helper.helper;

namespace ElectronicShop.Filters
{
    public class Authenticate: ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            var session = context.HttpContext.Session;
            if (!session.IsAvailable)
                Login(context);
            byte[] value;
            var x = session.TryGetValue("UserRole", out value);
            if (value == null)
            {
                Login(context);
            }
            else 
            {
                var role = session.GetInt32("UserRole");
                if (role.Value != (int)Roles.Customer&& role.Value != (int)Roles.Admin)
                {
                    Unauthorized(context);
                }

            }
          
          
            

        }
        private IActionResult Login(ActionExecutingContext context)
        {

            return context.Result = new RedirectToActionResult("Login", "User",null);

        }
        private IActionResult Unauthorized(ActionExecutingContext context)
        {
            return context.Result = new ContentResult()
            {
                Content = "Unauthorized to access specified resource.",
                StatusCode = StatusCodes.Status401Unauthorized
            };
        }
    }
}
