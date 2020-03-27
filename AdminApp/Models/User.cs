using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AdminApp.Models
{
    public class User
    {
        [Required]
        private bool IsStaff { get; set; }

        [Required]
        public DateTime DateRegd { get; set; }

        private string FullName => $"{FirstName} {LastName}";

        [Key]
        public string Id { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        public string PhoneNumber { get; set; }
    }
}
