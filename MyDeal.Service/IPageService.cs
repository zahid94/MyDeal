using MyDeal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MyDeal.Service
{
    public interface IPageService
    {
        Page AddPage(Page Page);
        bool UpdatePage(Page Page);
        bool RemovePage(Page Page);
        Page PageDetails(Expression<Func<Page, bool>> expression);
        IEnumerable<Page> GetAllPage(Expression<Func<Page, bool>> expression);
    }
}
