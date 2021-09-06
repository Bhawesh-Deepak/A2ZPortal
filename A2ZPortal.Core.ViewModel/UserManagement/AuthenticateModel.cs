using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A2ZPortal.Core.ViewModel.UserManagement
{
    public class AuthenticateModel
    {
        public string EmployeeName { get; set; }
        public string EmployeeCode { get; set; }
        public List<UserAccessDetailModel> UserAccessDetails { get; set; }
    }
}
