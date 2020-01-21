using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyDeal.Models.BidsInformation
{ 
    public class WinnerVM
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public string CustomerName { get; set; }
        public int ProductId { get; set; }        
        public string ProductName { get; set; }        
        public double BidsPrice { get; set; }        
        public DateTime BidsTime { get; set; }
    }
}
