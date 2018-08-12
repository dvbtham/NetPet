using PetNet.Data.Repositories;
using PetNet.Model.Models;

namespace PetNet.Service
{
    public interface ITransactionHistoryService
    {
        TransactionHistory AddTransactionHistory(TransactionHistory transactionHistory);
    }
    public class TransactionHistoryService : ITransactionHistoryService
    {
        private readonly ITransactionHistoryRepository _transactionHistoryRepository;
        public TransactionHistoryService(ITransactionHistoryRepository transactionHistoryRepository)
        {
            _transactionHistoryRepository = transactionHistoryRepository;
        }
        public TransactionHistory AddTransactionHistory(TransactionHistory transactionHistory)
        {
            return _transactionHistoryRepository.Add(transactionHistory);
        }
    }
}
