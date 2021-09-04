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
    [Table("AdditionalRoom", Schema = "Master")]
    public class AdditionalRoom : BaseModel<int>
    {
        [Required(ErrorMessage = "Room Name is Required.")]
        [Display(Prompt = "Enter Room Name.")]
        public string RoomName { get; set; }
    }
   
}
