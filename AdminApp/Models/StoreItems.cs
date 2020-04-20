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
        public string ItemName { get; set; }

        [Required]
        public int QuantityAdded { get; set; }

        public DateTime DateAdded { get; set; }

        public int QtyLeft { get; set; }

        public string ToString { get { return $"{ItemName}"; } }
    }
}
