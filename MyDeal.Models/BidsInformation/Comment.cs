using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyDeal.Models.BidsInformation
{
    public class Comment:Entity<int>
    {
        public string CommentText { get; set; }
        public int CustomerId { get; set; }
        public int ProductId { get; set; }
        public DateTime CommentTime { get; set; }

        public virtual Customer Customer { get; set; }
        public virtual Product Product { get; set; }
    }
}
