using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A2ZPortal.Core.ViewModel.UserManagement
{
    public class AuthModel
    {
        [Required(ErrorMessage ="User name is required.")]
        public string UserName { get; set; }

        [DataType(DataType.Password)]
        [Required(ErrorMessage ="Password is required.")]
        public string Password { get; set; }

        public string Message { get; set; }
    }
}
