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
    [Table("NumberOfParking", Schema = "Master")]
    public class NumberOfParking : BaseModel<int>
    {
        [Required(ErrorMessage = "Number Of Parking is Required.")]
        [Display(Prompt = "Enter Number Of Parking.")]
        public int TotalParking { get; set; }
    }
    
}
