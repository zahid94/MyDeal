using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Linq.Expressions;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Web.ModelBinding;
using MyDeal.Models;
using MyDeal.Repository;
using MyDeal.Service.Messaging;

namespace MyDeal.Service
{
    public class CustomerService : ICustomerService
    {
        private readonly IGenericRepository<Customer> repository;
        private readonly MyDealDbContext dbcontext;
        private readonly EmailSending email;
        
        public CustomerService()
        {
            repository = new GenericRepository<Customer>();
            dbcontext = new MyDealDbContext();
            email = new EmailSending();
        }
        public Customer CustomerDetails(Expression<Func<Customer, bool>> expression)
        {
            return repository.GetFirstOrDefault(expression);
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
                    string Email = Customer.Email;
                    string userName = Customer.UserName;
                    string subject = "welcome to mydeal";
                    string emailBody = " thanks you very much . it is your password ";

                    email.Email(Email,userName,subject,emailBody);                    

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

        public bool UpdateCustomer(Customer customer)
        {
            try
            {
                repository.EditEntity(customer);
                return repository.SaveToDatabase() > 0;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
