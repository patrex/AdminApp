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

        public DateTime DateRequeste => DateTime.Now;

        public APINUser UserRequesting { get; set; }

        public StoreItems Item { get; set; }
    }
}
