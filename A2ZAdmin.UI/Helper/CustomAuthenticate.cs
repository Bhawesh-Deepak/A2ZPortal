using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace A2ZAdmin.UI.Helper
{
    [AllowAnonymous]
    public class CustomAuthenticate : TypeFilterAttribute
    {
        public CustomAuthenticate() : base(typeof(ValidateRequestFilter))
        {
        }
    }
}
