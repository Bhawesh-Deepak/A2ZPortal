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
    [Table("BathRoom", Schema = "Master")]
    public class BathRoom : BaseModel<int>
    {
        [Required(ErrorMessage ="Bath Room is Required.")]
        [Display(Prompt = "Enter no of Bath Room.")]
        public int BathRooms { get; set; }
    }
}
