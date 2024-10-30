

using Transactions.Models;
using Transactions.Services;

namespace TransactionsTest
{
    public class TransactionServiceTests
    {
        private readonly TransactionService _transactionService;

        public TransactionServiceTests()
        {
            _transactionService = new TransactionService();
        }

        [Fact]
        public void AddTransaction_ShouldAddTransactionToList()
        {
            // Arrange
            var transaction = new Transaction
            {
                Id = 1,
                Type = "Credit",
                Amount = 100,
                Date = DateTime.Today
            };

            // Act
            _transactionService.AddTransaction(transaction);
            var transactions = _transactionService.GetTransactions(DateTime.Today);

            // Assert
            Assert.Single(transactions);
            Assert.Equal(transaction, transactions.First());
        }

        [Fact]
        public void GetTransactions_ShouldReturnTransactionsForSpecificDate()
        {
            // Arrange
            var today = DateTime.Today;
            var yesterday = today.AddDays(-1);

            var transaction1 = new Transaction
            {
                Id = 1,
                Type = "Credit",
                Amount = 100,
                Date = today
            };
            var transaction2 = new Transaction
            {
                Id = 2,
                Type = "Debit",
                Amount = 50,
                Date = yesterday
            };

            _transactionService.AddTransaction(transaction1);
            _transactionService.AddTransaction(transaction2);

            // Act
            var transactionsToday = _transactionService.GetTransactions(today);
            var transactionsYesterday = _transactionService.GetTransactions(yesterday);

            // Assert
            Assert.Single(transactionsToday);
            Assert.Equal(transaction1, transactionsToday.First());

            Assert.Single(transactionsYesterday);
            Assert.Equal(transaction2, transactionsYesterday.First());
        }

        [Fact]
        public void GetTransactions_ShouldReturnEmptyForNoTransactionsOnDate()
        {
            // Arrange
            var date = DateTime.Today;

            // Act
            var transactions = _transactionService.GetTransactions(date);

            // Assert
            Assert.Empty(transactions);
        }
    }
}