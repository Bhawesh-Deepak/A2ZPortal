using A2ZPortal.Core.Entities.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A2ZPortal.Core.Entities.Property
{
    [Table("UpComingPropertyDetail", Schema = "Property")]
    public class UpComingPropertyDetail : BaseModel<int>
    {
        [Required(ErrorMessage = "Property Name is Required.")]
        [Display(Prompt = "Enter Property Name.")]
        public string PropertyName { get; set; }
        [Required(ErrorMessage = "Property Description is Required.")]
        [Display(Prompt = "Enter Property Description.")]
        public string ProprtyDescription { get; set; }
        [Required(ErrorMessage = "Video URL is Required.")]
        [Display(Prompt = "Enter Video URL")]
        public string VideoURL { get; set; }
        public string ImagePath { get; set; }
    }
}
