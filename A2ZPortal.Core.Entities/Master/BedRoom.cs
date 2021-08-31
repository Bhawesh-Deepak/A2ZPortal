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
    [Table("BedRoom", Schema = "Master")]
    public class BedRoom : BaseModel<int>
    {
        [Required(ErrorMessage = "Bed Room is Required.")]
        [Display(Prompt = "Enter no of Bed Room.")]
        public int BedRooms { get; set; }
    }
}
