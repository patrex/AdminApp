using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AdminApp.Models
{
    public class Departments
    {
        [Key]
        public int DepartmentId { get; set; }

        [Required]
        [StringLength(6, ErrorMessage = "You need to enter a name for the department")]
        public string DepartmentName { get; set; }

        [StringLength(6, ErrorMessage ="You should enter at least 6 letters for name")]
        public string Supervisor { get; set; }
    }
}