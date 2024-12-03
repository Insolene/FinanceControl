using FinanceControl.Entities;

namespace FinanceControl.Data.Repository.Interface
{
    public interface ITransactionRepository
    {
        Task<List<TransactionEntities>> GetOperations();
        Task<TransactionEntities> GetById(int id);
        Task<TransactionEntities> AddTransaction(TransactionEntities transaction);
        Task<TransactionEntities> UpdateTransaction(TransactionEntities tr, int id);
        Task<bool> DeleteTransition(int id);
    }
}
