using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AdminApp.Models
{
    public class ItemIssues
    {
        [Key]
        public int RequestId { get; set; }

        [Required]
        public string RequesterEmail { get; set; }

        [Required]
        public string Issuer { get; set; }

        [Required]
        public int QuantityIssued { get; set; }

        [Required]
        public DateTime IssuedAt { get; set; }
    }
}
