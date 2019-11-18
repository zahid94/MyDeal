using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq.Expressions;
using MyDeal.Models;
using MyDeal.Repository;

namespace MyDeal.Service
{
    public class CategoryService : ICategoryService
    {
        private readonly IGenericRepository<Category> _repository;
        public CategoryService()
        {
            _repository = new GenericRepository<Category>();
        }
        public Category AddCategory(Category Category)
        {
            try
            {
                if (_repository.IsExist(x => x.Name == Category.Name))
                {
                    Category.Id = -1;
                    return Category;
                }
                else
                {
                   Category.Name= CultureInfo.CurrentCulture.TextInfo.ToTitleCase(Category.Name.ToLower());
                    _repository.AddEntity(Category);
                    _repository.SaveToDatabase();
                    return Category;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public Category CategoryDetails(Expression<Func<Category, bool>> expression)
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

        public IEnumerable<Category> GetAllCategory(Expression<Func<Category, bool>> expression)
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

        public bool RemoveCategory(Category Category)
        {
            try
            {
                _repository.RemoveEntity(Category);
                return _repository.SaveToDatabase() > 0;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool UpdateCategory(Category Category)
        {
            try
            {
                if (_repository.IsExist(x=>x.Name==Category.Name))
                {
                    Category.Id = -1;
                    return _repository.SaveToDatabase()>0;
                }
                else
                {
                    Category.Name = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(Category.Name.ToLower());
                    _repository.EditEntity(Category);
                    _repository.SaveToDatabase();
                    return _repository.SaveToDatabase()>0;
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
