using MyDeal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MyDeal.Service
{
    public interface ICustomerService:IDisposable
    {
        Customer Registration(Customer Customer);
        bool UpdatePassWord(Customer Customer);
        bool UpdateCustomer(Customer customer);
        Customer CustomerDetails(Expression<Func<Customer, bool>> expression);
        IEnumerable<Customer> GetAll(Expression<Func<Customer, bool>> expression);        
    }
}
