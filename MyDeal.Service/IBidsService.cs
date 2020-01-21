using MyDeal.Models.BidsInformation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MyDeal.Service
{
    public interface IBidsService
    {
        Bids AddBids(Bids Bids);

        //bool UpdateCategory(Category Category);
        bool RemoveBids(Bids bids);
        //Category CategoryDetails(Expression<Func<Category, bool>> expression);
        //IEnumerable<Bids> GetAll(Expression<Func<Bids, bool>> expression);
        IEnumerable<Bids> GetFilterBider(Expression<Func<Bids, bool>> expression);
        IEnumerable<Bids> GetAllBider(Expression<Func<Bids, bool>> expression);
    }
}
