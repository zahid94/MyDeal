using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyDeal.Models
{
    public class GallaryImage:Entity<int>
    {
        public string ImageName { get; set; }
        public int ProductId { get; set; }

        public virtual Product Product { get; set; }
    }
}
