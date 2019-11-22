using MyDeal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MyDeal.Service
{
    public interface IPageMenuService:IDisposable
    {
        Page PageDetails(Expression<Func<Page, bool>> expression);
        IEnumerable<Page> GetAllPage(Expression<Func<Page, bool>> expression);
    }
}
