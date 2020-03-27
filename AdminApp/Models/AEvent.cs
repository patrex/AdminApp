using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AdminApp.Models
{
    public class AEvent
    {
        [Key]
        public string Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Venue { get; set; }

        [Required]
        public string HostId { get; set; }

        [Required]
        public DateTime EventDateTime { get; set; }
    }
}
