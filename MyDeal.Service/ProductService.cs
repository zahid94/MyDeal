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
    public class ProductService : IProductService
    {
        private readonly IGenericRepository<Product> _repository;
        public ProductService()
        {
            _repository = new GenericRepository<Product>();
        }
        public Product AddProduct(Product product)
        {
            try
            {
                if (_repository.IsExist(x=>x.Title==product.Title))
                {
                    product.Id = -1;
                    return product;
                }
                else
                {
                    _repository.AddEntity(product);
                    _repository.SaveToDatabase();
                    return product;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public IEnumerable<Product> GetAllProduct(Expression<Func<Product, bool>> expression)
        {
            try
            {
                return _repository.GetAll(expression);
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
                return _repository.GetFirstOrDefault(expression);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool RemoveProduct(Product Page)
        {
            try
            {
                 _repository.RemoveEntity(Page);
                return _repository.SaveToDatabase() > 0;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool UpdateProduct(Product product)
        {
            try
            {
                if (_repository.IsExist(x=>x.Title==product.Title))
                {
                    product.Id = -1;
                    return _repository.SaveToDatabase()>0;
                }
                else
                {
                    _repository.EditEntity(product);
                    return _repository.SaveToDatabase() > 0;
                }

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
