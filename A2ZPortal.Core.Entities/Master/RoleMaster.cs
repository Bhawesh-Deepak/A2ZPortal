using A2ZPortal.Core.Entities.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A2ZPortal.Core.Entities.Master
{
    [Table("RoleMaster", Schema = "Master")]
    public class RoleMaster : BaseModel<int>
    {
        [Required(ErrorMessage ="Role Name is required ")]
        [Display(Prompt = "Enter Role name.")]
        [MaxLength(200, ErrorMessage = "Role name is too large.")]
        public string RoleName { get; set; }
    }
}
