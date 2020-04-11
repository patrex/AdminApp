using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AdminApp.Models
{
    public class OnGoingEvent
    {
        [Key]
        public int EventID { get; set; }

        [Required]
        public int UserID { get; set; }
    }
}
