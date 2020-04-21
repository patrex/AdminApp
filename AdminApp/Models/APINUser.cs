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
        public string eMail { get; set; }

        [Required]
        public string Pswd { get; set; }

        [Required]
        public string Firstname { get; set; }

        [Required]
        public string Lastname { get; set; }

        public bool IsAdmin { get; set; }

        [Required]
        public string Department { get; set; }

        public string Fullname => $"{Firstname} {Lastname}";

        public string ToString 
        { 
            get { return Fullname; }
        }

        public bool IsElevatedUser { get; set; }
    }
}
