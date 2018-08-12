using PetNet.Data.Infrastructure;
using PetNet.Model.Models;

namespace PetNet.Data.Repositories
{
    public interface IVisitorStatisticRepository : IRepository<VisitorStatistic> { }

    internal class VisitorStatisticRepository : RepositoryBase<VisitorStatistic>,IVisitorStatisticRepository
    {
        public VisitorStatisticRepository(IDbFactory dbFactory)
            : base(dbFactory)
        {
        }
    }
}