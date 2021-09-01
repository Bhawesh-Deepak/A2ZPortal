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
    [Table("Employee", Schema = "UserManagement")]
    public class Employee : BaseModel<int>
    {
        [Required(ErrorMessage = "Role is Required.")]
        [Display(Prompt = "Enter Role .")]
        public int RoleId { get; set; }
        [Required(ErrorMessage = "EmpCode is Required.")]
        [Display(Prompt = "Enter EmpCode .")]
        public string EmpCode { get; set; }
        [Required(ErrorMessage = "Employee Name is Required.")]
        [Display(Prompt = "Enter Employee Name .")]
        public string EmployeeName { get; set; }
        [Required(ErrorMessage = "Phone Number is Required.")]
        [Display(Prompt = "Enter Phone Number.")]
        [MaxLength(10, ErrorMessage = "Phone Number is too large.")]
        public string Phone { get; set; }
        [Required(ErrorMessage = "Email is Required.")]
        [Display(Prompt = "Enter Email.")]
        public string Email { get; set; }
        [Required(ErrorMessage = "User Name is Required.")]
        [Display(Prompt = "Enter User Name.")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "Password is Required.")]
        [Display(Prompt = "Enter Password.")]
        public string Password { get; set; }

    }
     
}
