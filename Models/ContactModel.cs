using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HMZSoftwareBlazorWebAssembly.Models
{
    public class ContactModel
    {
        [Required]
        [StringLength(50, ErrorMessage = "Name can't be more than {1} characters.")]
        public string FullName { get; set; }

        [Required]
        [EmailAddress]
        [DataType(DataType.EmailAddress)]
        [StringLength(150, ErrorMessage = "Email can't be more than {1} characters.")]
        public string Email { get; set; }

        [Required]
        [StringLength(150, ErrorMessage = "Subject can't be more than {1} characters.")]
        public string Subject { get; set; }

        [Required]
        [DataType(DataType.MultilineText)]
        [StringLength(5000, MinimumLength = 30, ErrorMessage = "Message should be between {2} and {1} characters.")]
        public string Message { get; set; }
    }
}
