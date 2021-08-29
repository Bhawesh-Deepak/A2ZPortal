using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using A2ZPortal.Core.Entities.Common;

namespace A2ZPortal.Core.Entities.Master
{
    [Table("ModuleMaster",Schema = "Master")]
    public class ModuleMaster: BaseModel<int>
    {
        [Required(ErrorMessageResourceName = "ModuleName", ErrorMessageResourceType = typeof(ValidationResource) )]
        [Display(Prompt = "Enter Module name.")]
        [MaxLength(200,ErrorMessage = "Module name is too large.")]
        public string ModuleName { get; set; }
        [Display(Prompt = "Enter Sort Order.")]
        public int  SortOrder { get; set; }
        public string IconImagePath { get; set; }
    }
}