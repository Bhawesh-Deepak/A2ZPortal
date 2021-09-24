using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A2ZPortal.Helper.Extension
{
    public static class SqlConstant
    {
        public const string GetPropertyDetails = @"usp_GetPropertyDetail";
        public const string GetSubModuleDetails = @"Master.usp_GetSubModuleDetails";
        public const string GetRoleAccessDetails = @"Master.usp_GetRoleAccess";
        public const string AuthenticateUser = @"usp_Authenticate";
        public const string GetPropertyList = @"usp_GetPropertyDetails";
        public const string GetPropertyDetailList = @"usp_GetCompletePropertyDetail";
        public const string GetFeaturedProperty = @"usp_GetFeaturedProperty";
        public const string GetCompletePropertyDetails = @"usp_GetPropertyDetailList";
        public const string GetPropertyCompleteDetail = @"usp_GetPropertyCompleteDetails";
        public const string GetTestimonialCompleteDetail = @"usp_GetTestimonial";
        public const string GetPropertyDetailByName = @"usp_GetPropertyDetailByPropertyType";
        public const string GetCustomerCartDetails = @"usp_GetCustomerCartDetails";
        public const string GetRecentPropertyDetails = @"usp_GetRecentPropertyDetail";
        public const string GetPropertyLocationWiseCount = @"usp_GetPropertyDetailCount";
        public const string GetRecentPropertyDetail = @"usp_GetRecentProperty";
        public const string GetVirtualImage = @"usp_GetPrimaryImage";
    }
}
