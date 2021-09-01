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
    [Table("SubModuleMaster", Schema = "Master")]
    public class SubModuleMaster : BaseModel<int>
    {
        [Required(ErrorMessage = "ModuleId is Required.")]
        [Display(Prompt = "Enter ModuleId.")]
        public int ModuleId { get; set; }
        [Required(ErrorMessage = "SubModule Name is Required.")]
        [Display(Prompt = "Enter SubModule Name.")]
        public string SubModuleName { get; set; }
        [Required(ErrorMessage = "Area Name  is Required.")]
        [Display(Prompt = "Enter Area  Name.")]
        public string AreaName { get; set; }
        [Required(ErrorMessage = "Controller  Name is Required.")]
        [Display(Prompt = "Enter Controller  Name.")]
        public string ControllerName { get; set; }
        [Required(ErrorMessage = "Action  Name is Required.")]
        [Display(Prompt = "Enter Action  Name.")]
        public string ActionName { get; set; }
        [Required(ErrorMessage = "Sort Order    is Required.")]
        [Display(Prompt = "Enter SortOrder.")]
        public int SortOrder { get; set; }
        [Required(ErrorMessage = "Icon/Image Path  is Required.")]
        [Display(Prompt = "Enter Icon/Image Path.")]
        public string IconImagePath { get; set; }
    }

}
