using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
 
namespace A2ZPortal.Core.ViewModel.MasterModel
{
    public class SubModuleViewModel 
    {
        public int Id { get; set; }
        public string ModuleName { get; set; }
        public string SubModuleName { get; set; }
        public string AreaName { get; set; }
        public string ControllerName { get; set; }
        public string ActionName { get; set; }
        public int SortOrder { get; set; }
        public string IconImagePath { get; set; }
    }
}
