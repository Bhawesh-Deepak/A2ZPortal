using A2ZPortal.Core.Entities.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A2ZPortal.Core.Entities.UserManagement
{
    [Table("RoleAccess",Schema = "UserManagement")]
    public class RoleAccessDetail: BaseModel<int>
    {
        public int RoleId { get; set; }
        public int ModuleId { get; set; }
        public int SubModuleId { get; set; }
        public bool IsEdit { get; set; } = false;
        public bool IsDelete { get; set; } = false;
        public bool IsCreate { get; set; } = false;
        public bool IsUpdate { get; set; } = false;
    }
}
