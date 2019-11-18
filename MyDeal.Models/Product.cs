using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace MyDeal.Models
{
    public class Product:Entity<int>
    {
        [Required]
        [MaxLength(50)]
        public string Title { get; set; }
        public string Description { get; set; }        
        public int CategoryId { get; set; }
        public int TotalBids { get; set; }
        [Required]
        public decimal ActualPrice { get; set; }
        public decimal CurrentPrice { get; set; }
        [Required]
        public DateTime BidEndDate { get; set; }
        public decimal Rating { get; set; }
        
        public string ImageName { get; set; }

        public virtual Category Category { get; set; }
    }
}
