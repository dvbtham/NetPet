using PetNet.Data.Infrastructure;
using PetNet.Model.Models;

namespace PetNet.Data.Repositories
{
    public interface ISystemConfigRepository : IRepository<SystemConfig> { }

    public class SystemConfigRepository : RepositoryBase<SystemConfig>, ISystemConfigRepository
    {
        public SystemConfigRepository(IDbFactory dbFactory)
            : base(dbFactory)
        {
        }
    }
}