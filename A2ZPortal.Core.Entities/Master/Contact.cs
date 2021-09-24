using A2ZPortal.Core.Entities.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A2ZPortal.Core.Entities.Master
{
    [Table("Contact", Schema = "Master")]
    public class Contact : BaseModel<int>
    {
        public string Name { get; set; }
        public string EmailId { get; set; }
        public string Subject { get; set; }
        public string Message { get; set; }
        [NotMapped]
        public string ErrorMessage { get; set; }

        [NotMapped]
        public string ReturnUrl { get; set; }
    }
}
