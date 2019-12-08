using MyDeal.Models;
using MyDeal.Models.BidsInformation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MyDeal.Service
{
    public interface IShopService:IDisposable
    {
        Product ProductDetails(Expression<Func<Product, bool>> expression);
        IEnumerable<Product> GetAllProduct(Expression<Func<Product, bool>> expression);
        IEnumerable<Bids> GetFilterBider(Expression<Func<Bids, bool>> expression);
        IEnumerable<Product> GetFilterProduct(Expression<Func<Product, bool>> expression);
    }
}
