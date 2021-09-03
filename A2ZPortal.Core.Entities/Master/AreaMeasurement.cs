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
    [Table("AreaMeasurement", Schema = "Master")]
    public class AreaMeasurement : BaseModel<int>
    {
        [Required(ErrorMessage = "Area of Measurement is Required.")]
        [Display(Prompt = "Enter Area of Measurement.")]
        public string MeasurementType { get; set; }
    }

}
