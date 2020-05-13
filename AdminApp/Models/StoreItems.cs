using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AdminApp.Models
{
    public class StoreItems
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 5)]
        public string ItemName { get; set; }

        [Required]
        public string AddedBy { get; set; }

        [Required]
        [Range(1, 1000, ErrorMessage = "Invalid amount. Must be 1 or more")]
        public int QuantityAdded { get; set; }

        public DateTime DateAdded { get; set; }

        public int QtyLeft { get; set; }

        public string ToString { get { return $"{ItemName}"; } }
    }
}
