using PetNet.Data.Infrastructure;
using PetNet.Model.Models;

namespace PetNet.Data.Repositories
{
    public interface IPostCategoryRepository : IRepository<PostCategory> { }

    public class PostCategoryRepository : RepositoryBase<PostCategory>,IPostCategoryRepository
    {
        public PostCategoryRepository(IDbFactory dbFactory)
            : base(dbFactory)
        {
        }
    }
}