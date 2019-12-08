using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyDeal.Models.BidsInformation
{
    public class Bids:Entity<int>
    {
        public int CustomerId { get; set; }
        public int ProductId { get; set; }
        [Required]
        public double BidsPrice { get; set; }
        public DateTime BidsTime { get; set; }

        public virtual Customer Customer { get; set; }
        public virtual Product  Product{ get; set; }
    }
}
