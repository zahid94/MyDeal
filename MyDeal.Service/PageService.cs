using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq.Expressions;
using MyDeal.Models;
using MyDeal.Repository;

namespace MyDeal.Service
{
    public class PageService : IPageService
    {
        private readonly IGenericRepository<Page> _repository;
        private readonly MyDealDbContext _dbcontext;
        public PageService()
        {
            _repository = new GenericRepository<Page>();
            _dbcontext = new MyDealDbContext();
        }
        public Page AddPage(Page Page)
        {
            try
            {
                if (_repository.IsExist(x=>x.Name==Page.Name))
                {
                    Page.Id = -1;
                    return Page;
                }         
                Page.Name = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(Page.Name.ToLower());
                _repository.AddEntity(Page);
                _repository.SaveToDatabase();
                return Page;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public IEnumerable<Page> GetAllPage(Expression<Func<Page, bool>> expression)
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

        public Page PageDetails(Expression<Func<Page, bool>> expression)
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

        public bool RemovePage(Page Page)
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

        public bool UpdatePage(Page Page)
        {
            try
            {
                Page.Name = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(Page.Name.ToLower());
                _repository.EditEntity(Page);
                return _repository.SaveToDatabase() > 0;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
