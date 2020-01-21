using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using MyDeal.Models.BidsInformation;
using MyDeal.Repository;

namespace MyDeal.Service
{
    public class BidsService : IBidsService
    {
        private readonly IGenericRepository<Bids> repository;
        public BidsService()
        {
            repository = new GenericRepository<Bids>();
        }

        public Bids AddBids(Bids Bids)
        {
            try
            {
                repository.AddEntity(Bids);
                repository.SaveToDatabase();
                return Bids;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public IEnumerable<Bids> GetFilterBider(Expression<Func<Bids, bool>> expression)
        {
            try
            {
                return repository.GetFilterRecord(expression);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public IEnumerable<Bids> GetAllBider(Expression<Func<Bids, bool>> expression)
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

        public bool RemoveBids(Bids bids)
        {
            try
            {
                repository.RemoveEntity(bids);
                return repository.SaveToDatabase() > 0;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
