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
    public class CommentService : ICommentService
    {
        private readonly IGenericRepository<Comment> repository;
        public CommentService()
        {
            repository = new GenericRepository<Comment>();
        }
        public Comment Add(Comment comment)
        {
            repository.AddEntity(comment);
            repository.SaveToDatabase();
            return comment;
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Comment> GetFilterComment(Expression<Func<Comment, bool>> expression)
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
    }
}
