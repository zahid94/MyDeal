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

                    MailMessage mail = new MailMessage(ConfigurationManager.AppSettings["Email"].ToString(),Customer.Email);
                    mail.Subject = "Welcome to MyDeal";
                    mail.Body ="Dear Client "+ Customer.UserName + " Thanks You very much for registration our site. Now you are valid all of rules.";
                    mail.IsBodyHtml = false;

                    SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587);
                    smtp.EnableSsl = true;
                    smtp.DeliveryMethod = SmtpDeliveryMethod.Network;

                    NetworkCredential credential = new NetworkCredential(ConfigurationManager.AppSettings["Email"].ToString(), ConfigurationManager.AppSettings["password"].ToString());
                    smtp.UseDefaultCredentials = false;
                    smtp.Credentials = credential;
                    smtp.Send(mail);

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
