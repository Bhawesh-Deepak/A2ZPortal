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
    [Table("ViewFacing", Schema = "Master")]
    public class ViewFacing : BaseModel<int>
    {
        [Required(ErrorMessage = "View Facing is Required.")]
        [Display(Prompt = "Enter View Facing.")]
        public string Facing { get; set; }
    }
   
}
