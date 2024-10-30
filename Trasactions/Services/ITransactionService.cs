using Transactions.Models;

namespace Transactions.Services
{
    public interface ITransactionService
    {
        void AddTransaction(Transaction transaction);
        IEnumerable<Transaction> GetTransactions(DateTime date);
    }
}
