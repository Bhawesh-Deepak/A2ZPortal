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
    [Table("Budget", Schema = "Master")]
    public class Budget : BaseModel<int>
    {
        [Required(ErrorMessage = "Budgets is Required.")]
        [Display(Prompt = "Enter Budgets.")]
        public decimal Budgets { get; set; }
    }
  
}
