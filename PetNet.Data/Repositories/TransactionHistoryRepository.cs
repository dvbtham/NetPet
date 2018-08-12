using PetNet.Data.Infrastructure;
using PetNet.Model.Models;

namespace PetNet.Data.Repositories
{
    public interface ITransactionHistoryRepository : IRepository<TransactionHistory>
    {
       
    }

    public class TransactionHistoryRepository : RepositoryBase<TransactionHistory>, ITransactionHistoryRepository
    {
        public TransactionHistoryRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }
    }
}
