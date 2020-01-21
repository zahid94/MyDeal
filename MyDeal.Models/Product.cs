using MyDeal.Models.BidsInformation;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace MyDeal.Models
{
    public class Product:Entity<int>
    {
        [Required]
        [MaxLength(50)]
        public string Title { get; set; }
        [AllowHtml]
        public string Description { get; set; }        
        public int CategoryId { get; set; }
        public int TotalBids { get; set; }
        [Required]
        public double ActualPrice { get; set; }
        public double CurrentPrice { get; set; }
        [Required]
        public DateTime BidEndDate { get; set; }
        public bool DisableBids { get; set; }
        public decimal Rating { get; set; }        
        public string ImageName { get; set; }


        public virtual Category Category { get; set; }
        public virtual ICollection<Bids> Bids { get; set; }
        public virtual ICollection<Comment> Comment { get; set; }
        public virtual ICollection<GallaryImage> GallaryImages { get; set; }
    }
}
