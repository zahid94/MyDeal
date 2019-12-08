using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace MyDeal.Models
{
    public class Page:Entity<int>
    {
        [Required]
        public string Name { get; set; }
        [Required]
        [AllowHtml]
        public string Description { get; set; }
    }
}
