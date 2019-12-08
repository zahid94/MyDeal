using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Web.ModelBinding;
using MyDeal.Models;
using MyDeal.Repository;

namespace MyDeal.Service
{
    public class CustomerService : ICustomerService
    {
        private readonly IGenericRepository<Customer> repository;
        private readonly MyDealDbContext dbcontext;
        public CustomerService()
        {
            repository = new GenericRepository<Customer>();
            dbcontext = new MyDealDbContext();
        }
        public Customer CustomerDetails(Expression<Func<Customer, bool>> expression)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Customer> GetAll(Expression<Func<Customer, bool>> expression)
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

        public Customer Registration(Customer Customer)
        {
            try
            {
                if (repository.IsExist(x=>x.UserName==Customer.UserName|| x.Email==Customer.Email))
                {
                    Customer.Id = -1;
                    return Customer;
                }
                else
                {
                    repository.AddEntity(Customer);
                    repository.SaveToDatabase();
                    return Customer;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
       

        public bool UpdatePassWord(Customer Customer)
        {
            throw new NotImplementedException();
        }
    }
}
