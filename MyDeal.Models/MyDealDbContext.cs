using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyDeal.Models
{
    public class MyDealDbContext:DbContext
    {
        public MyDealDbContext():base("Db")
        {

        }
        public DbSet<Page> pages { get; set; }
        public DbSet<Category> categories { get; set; }
        public DbSet<Product> products { get; set; }
        public DbSet<HomePageSlider> homePageSliders { get; set; }
    }
}
