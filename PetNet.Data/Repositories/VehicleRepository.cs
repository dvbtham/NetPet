using PetNet.Data.Infrastructure;
using PetNet.Model.Models;

namespace PetNet.Data.Repositories
{
    public interface IVehicleRepository : IRepository<Vehicle>
    {
    }

    public class VehicleRepository : RepositoryBase<Vehicle>, IVehicleRepository
    {
        public VehicleRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }
    }
}