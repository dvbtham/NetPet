using PetNet.Data.Infrastructure;
using PetNet.Model.Models;

namespace PetNet.Data.Repositories
{
    public interface IFooterRespository : IRepository<Footer>
    {
    }

    public class FooterRepository : RepositoryBase<Footer>, IFooterRespository
    {
        public FooterRepository(IDbFactory dbFactory)
            : base(dbFactory)
        {
        }
    }
}