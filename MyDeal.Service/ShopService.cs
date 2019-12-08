using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using MyDeal.Models;
using MyDeal.Models.BidsInformation;
using MyDeal.Repository;

namespace MyDeal.Service
{
    public class ShopService : IShopService
    {
        private readonly IGenericRepository<Product> repository;
        private readonly IGenericRepository<Bids> repositorybid;
        public ShopService()
        {
            repository = new GenericRepository<Product>();
            repositorybid = new GenericRepository<Bids>();
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

        public IEnumerable<Bids> GetFilterBider(Expression<Func<Bids, bool>> expression)
        {
            try
            {
                return repositorybid.GetFilterRecord(expression);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
