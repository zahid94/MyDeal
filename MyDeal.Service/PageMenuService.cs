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
    public class PageMenuService : IPageMenuService
    {
        private readonly IGenericRepository<Page> repository;
        public PageMenuService()
        {
            repository = new GenericRepository<Page>();
        }
        
        public IEnumerable<Page> GetAllPage(Expression<Func<Page, bool>> expression)
        {
            return repository.GetAll(expression);
        }

        public Page PageDetails(Expression<Func<Page, bool>> expression)
        {
            return repository.GetFirstOrDefault(expression);
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
