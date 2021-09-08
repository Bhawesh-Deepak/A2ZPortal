using A2ZPortal.Core.ViewModel.UserManagement;
using A2ZPortal.Helper.Extension;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Collections.Generic;

namespace A2ZAdmin.UI.Helper
{
    public class ValidateRequestFilter : IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            var url = context.HttpContext.Request.GetDisplayUrl();
            if (context.HttpContext.Session.GetObject<List<UserAccessDetailModel>>("AccessInformation") == null)
            {
                context.Result = new RedirectToActionResult("Index", "Authenticate", 
                    new { returnUrl = url });

            }
        }
    }
}