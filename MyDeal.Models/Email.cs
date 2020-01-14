using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyDeal.Models
{
   public class Email
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public int productPrice { get; set; }
        public string ProductName { get; set; }
        public int CustomerId { get; set; }
        public string EmailTo { get; set; }
        public string EmailSubject { get; set; }
        public string EmailBody { get; set; }
    }
}
