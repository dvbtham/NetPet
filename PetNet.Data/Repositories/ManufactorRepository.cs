using PetNet.Data.Infrastructure;
using PetNet.Model.Models;

namespace PetNet.Data.Repositories
{
    public class ManufactorRepository : RepositoryBase<Manufactor>, IManufactorRepository
    {
        public ManufactorRepository(IDbFactory dbFactory)
           : base(dbFactory)
        {
        }
    }

    public interface IManufactorRepository : IRepository<Manufactor>
    {
    }
}
