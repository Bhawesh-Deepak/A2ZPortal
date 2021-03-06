using A2ZPortal.Core.Entities.Common;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace A2ZPortal.Core.Entities.Customers
{
    [Table("Customers", Schema = "Customer")]
    public class CustomerDetails : BaseModel<int>
    {
        [Required(ErrorMessage = "Customer name is required.")]
        public string CustomerName { get; set; }

        [Required(ErrorMessage = "Customer phone is required.")]
        [RegularExpression(@"^(\d{10})$", ErrorMessage = "Wrong mobile")]
        [DataType(DataType.PhoneNumber, ErrorMessage = "Phone is invalid.")]
        public string CustomerPhone { get; set; }

        [Required(ErrorMessage = "Customer email is required.")]
        [DataType(DataType.EmailAddress, ErrorMessage = "Email is invalid.")]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        public string CustomerEmail { get; set; }
        public string PlaceId { get; set; }
        public string Longitude { get; set; }
        public string Latitude { get; set; }
        public string PlaceAddress { get; set; }
        public string OTP { get; set; }
        public DateTime? OTPSentTime { get; set; }
        [NotMapped]
        public string Message { get; set; }

        [NotMapped]
        public string ReturnUrl { get; set; }

        [Required(ErrorMessage = "Password is required.")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [NotMapped]
        [Compare("Password")]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }
    }
}
