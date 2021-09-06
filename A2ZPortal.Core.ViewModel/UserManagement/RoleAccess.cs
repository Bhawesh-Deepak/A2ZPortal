using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A2ZPortal.Core.ViewModel.UserManagement
{
    public class RoleAccess
    {
        public int Id { get; set; }
        public string MoudleName { get; set; }
        public string SubModuleName { get; set; }
        public string ControllerName { get; set; }
        public string ActionName { get; set; }
        public bool IsAccess { get; set; }
        public int RoleAccessId { get; set; }
        public int SubModuleId { get; set; }
    }
}
