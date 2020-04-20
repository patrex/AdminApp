using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AdminApp.Models
{
    public class Requests
    {
        [Key]
        public int RequestId { get; set; }

        [Required]
        public int QuantityRequested { get; set; }

        [Required]
        public string Purpose { get; set; }

        public bool IsApproved { get; set; }

        public DateTime DateRequested { get; set; }

        [Required]
        public string UserRequesting { get; set; }

        [Required]
        public string Item { get; set; }
    }
}
