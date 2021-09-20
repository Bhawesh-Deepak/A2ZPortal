using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace A2ZPortal.UI.Helper
{
    public class ValidateRequestFilter: IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            var url = context.HttpContext.Request.GetDisplayUrl();
            if (context.HttpContext.Session.GetString("UserPhone") == null)
            {
                context.Result = new RedirectToActionResult("Index", "CustomerDetail",
                    new { returnUrl = url });

            }
        }
    }
}