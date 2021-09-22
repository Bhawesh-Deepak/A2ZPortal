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
        public static string GetPropertyList = @"usp_GetPropertyDetails";
        public static string GetPropertyDetailList = @"usp_GetCompletePropertyDetail";
        public static string GetFeaturedProperty = @"usp_GetFeaturedProperty";
        public static string GetCompletePropertyDetails = @"usp_GetPropertyDetailList";
        public static string GetPropertyCompleteDetail = @"usp_GetPropertyCompleteDetails";
        public static string GetTestimonialCompleteDetail = @"usp_GetTestimonial";
        public static string GetPropertyDetailByName = @"usp_GetPropertyDetailByPropertyType";
        public static string GetCustomerCartDetails = @"usp_GetCustomerCartDetails";
        public static string GetRecentPropertyDetails = @"usp_GetRecentPropertyDetail";
        public static string GetPropertyLocationWiseCount = @"usp_GetPropertyDetailCount";
        public static string GetRecentPropertyDetail = @"usp_GetRecentProperty";
    }
}
