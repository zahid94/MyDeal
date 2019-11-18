using MyDeal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MyDeal.Service
{
    public interface IProductService:IDisposable
    {
        Product AddProduct(Product product);
        bool UpdateProduct(Product product);
        bool RemoveProduct(Product product);
        Product ProductDetails(Expression<Func<Product, bool>> expression);
        IEnumerable<Product> GetAllProduct(Expression<Func<Product, bool>> expression);
    }
}
