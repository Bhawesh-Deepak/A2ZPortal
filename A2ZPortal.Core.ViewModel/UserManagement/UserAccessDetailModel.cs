using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A2ZPortal.Core.ViewModel.UserManagement
{
    public class UserAccessDetailModel
    {
        public string SubModuleName { get; set; }
        public string ModuleName { get; set; }
        public string ActionName { get; set; }
        public string ControllerName { get; set; }
        public string ModuleIcon { get; set; }
        public string SubModuleIcon { get; set; }
    }
}
