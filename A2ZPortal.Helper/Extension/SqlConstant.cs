using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A2ZPortal.Helper.Extension
{
    public static class SqlConstant
    {
        public static string GetPropertyDetails = @"usp_GetPropertyDetail";
        public static string GetSubModuleDetails = @"Master.usp_GetSubModuleDetails";
        public static string GetRoleAccessDetails = @"Master.usp_GetRoleAccess";
        public static string AuthenticateUser = @"usp_Authenticate";
    }
}
