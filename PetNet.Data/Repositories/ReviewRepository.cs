using PetNet.Data.Infrastructure;
using PetNet.Model.Models;

namespace PetNet.Data.Repositories
{
    public interface IReviewRepository : IRepository<Review> {}

    public class ReviewRepository : RepositoryBase<Review>, IReviewRepository
    {
        public ReviewRepository(IDbFactory dbFactory)
           : base(dbFactory)
        {
        }
    }
}
