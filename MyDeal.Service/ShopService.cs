using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using MyDeal.Models;
using MyDeal.Repository;

namespace MyDeal.Service
{
    public class ShopService : IShopService
    {
        private readonly IGenericRepository<Product> repository;
        public ShopService()
        {
            repository = new GenericRepository<Product>();
        }
        public IEnumerable<Product> GetAllProduct(Expression<Func<Product, bool>> expression)
        {
            try
            {
                return repository.GetAll(expression);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public Product ProductDetails(Expression<Func<Product, bool>> expression)
        {
            try
            {
                return repository.GetFirstOrDefault(expression);
            }
            catch (Exception)
            {

                throw;
            }
        }
        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
