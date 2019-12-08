using MyDeal.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MyDeal.Repository
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class
    {
        private readonly MyDealDbContext dbContext;
        private readonly DbSet<TEntity> entities;
        public GenericRepository()
        {
            dbContext = new MyDealDbContext();
            entities = dbContext.Set<TEntity>();
        }
        public TEntity AddEntity(TEntity entity)
        {
            try
            {
                return entities.Add(entity);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public EntityState EditEntity(TEntity entity)
        {
            try
            {
                return dbContext.Entry(entity).State = EntityState.Modified;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public IEnumerable<TEntity> GetAll(Expression<Func<TEntity, bool>> expression)
        {
            try
            {
                return entities.ToList();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public IEnumerable<TEntity> GetFilterRecord(Expression<Func<TEntity, bool>> expression)
        {
            try
            {
                return entities.Where(expression).ToList();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public TEntity GetFirstOrDefault(Expression<Func<TEntity, bool>> expression)
        {
            try
            {
                return entities.FirstOrDefault(expression);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public TEntity GetLastOrDefault(Expression<Func<TEntity, bool>> expression)
        {
            try
            {
                return entities.LastOrDefault(expression);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool IsExist(Expression<Func<TEntity, bool>> expression)
        {
            try
            {
                return entities.Any(expression);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public EntityState RemoveEntity(TEntity entity)
        {
            try
            {
                return dbContext.Entry(entity).State = EntityState.Deleted;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public int SaveToDatabase()
        {
            try
            {
                return dbContext.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
