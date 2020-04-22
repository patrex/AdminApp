using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AdminApp.Models
{
    public class APINUser
    {
        [Key]
        [EmailAddress]
        public string eMail { get; set; }

        [Required]
        [StringLength(30, MinimumLength = 6, ErrorMessage = "Password must have at least 6 letters")]
        public string Password { get; set; }

        [Required]
        [StringLength(30, MinimumLength = 3, ErrorMessage ="First name must have at least 3 letters")]
        public string Firstname { get; set; }

        [Required]
        [StringLength(30, MinimumLength = 3, ErrorMessage = "Last name must have at least 3 letters")]
        public string Lastname { get; set; }

        public bool IsAdmin { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "You need to select a department from the list")]
        public string Department { get; set; }

        public string Fullname => $"{Firstname} {Lastname}";

        public string ToString 
        { 
            get { return Fullname; }
        }

        public bool IsElevatedUser { get; set; }
    }
}
