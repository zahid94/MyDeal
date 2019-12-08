using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MyDeal.Repository
{
    public interface IGenericRepository<TEntity> where TEntity:class
    {
        bool IsExist(Expression<Func<TEntity, bool>> expression);
        TEntity AddEntity(TEntity entity);
        EntityState EditEntity(TEntity entity);
        EntityState RemoveEntity(TEntity entity);
        TEntity GetFirstOrDefault(Expression<Func<TEntity, bool>> expression);
        TEntity GetLastOrDefault(Expression<Func<TEntity, bool>> expression);
        IEnumerable<TEntity> GetAll(Expression<Func<TEntity, bool>> expression);
        IEnumerable<TEntity> GetFilterRecord(Expression<Func<TEntity, bool>> expression);
        int SaveToDatabase();
    }
}
