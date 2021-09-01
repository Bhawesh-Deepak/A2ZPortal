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
    [Table("Location", Schema = "Master")]
    public class Location:BaseModel<int>
    {
        [Required(ErrorMessage ="Location name is required.")]
        [Display(Prompt ="Enter Display name")]
        public string LocationName { get; set; }
    }
}
