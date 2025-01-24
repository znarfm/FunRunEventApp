using System.ComponentModel.DataAnnotations;

namespace FunRunEventApp.Models
{
    public class RegistrationModel
    {
        [Required, Display(Name = "Full Name")]
        public string FullName { get; set; }

        [Required, EmailAddress, Display(Name = "Email Address")]
        public string Email { get; set; }

        [Required, Display(Name = "Contact Number"), Phone]
        public string ContactNumber { get; set; }

        [Required, Range(17, 120), Display(Name = "Age")]
        public int Age { get; set; }

        [Required, Display(Name = "Gender")]
        public string Gender { get; set; }

        [Required, Display(Name = "Run Distance")]
        public string Category { get; set; }

        [Required, Display(Name = "T-shirt Size")]
        public string TShirtSize { get; set; }

        [Required, Display(Name = "Emergency Contact Name")]
        public string EmergencyContactName { get; set; }

        [Required, Display(Name = "Emergency Contact Number"), Phone]
        public string EmergencyContactNumber { get; set; }
    }
}
