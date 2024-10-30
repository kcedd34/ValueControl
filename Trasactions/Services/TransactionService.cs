using Transactions.Models;

namespace Transactions.Services
{
    public class TransactionService : ITransactionService
    {
        private readonly List<Transaction> _transactions = new(); // Simulating a database

        public void AddTransaction(Transaction transaction)
        {
            _transactions.Add(transaction);
        }

        public void AddTransaction(System.Transactions.Transaction transaction)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Transaction> GetTransactions(DateTime date)
        {
            return _transactions.Where(t => t.Date.Date == date.Date);
        }

    }
}
