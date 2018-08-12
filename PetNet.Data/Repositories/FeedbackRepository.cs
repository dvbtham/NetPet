using PetNet.Data.Infrastructure;
using PetNet.Model.Models;

namespace PetNet.Data.Repositories
{
    public interface IFeedbackRepository : IRepository<Feedback>
    {
    }

    public class FeedbackRepository : RepositoryBase<Feedback>, IFeedbackRepository
    {
        public FeedbackRepository(IDbFactory dbFactory)
            : base(dbFactory)
        {
        }
    }
}