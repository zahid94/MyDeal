using MyDeal.Models;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace MyDeal.Service
{
    public interface ICategoryService:IDisposable
    {
        Category AddCategory(Category Category);
        bool UpdateCategory(Category Category);
        bool RemoveCategory(Category Category);
        Category CategoryDetails(Expression<Func<Category, bool>> expression);
        IEnumerable<Category> GetAllCategory(Expression<Func<Category, bool>> expression);
    }
}
