using MyDeal.Models.BidsInformation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MyDeal.Service
{
    public interface ICommentService:IDisposable
    {
        Comment Add(Comment comment);
        IEnumerable<Comment> GetFilterComment(Expression<Func<Comment, bool>> expression);
    }
}
