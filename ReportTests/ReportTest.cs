using Moq;
using Transactions.Services;
using Report.Services;
using Transactions.Models;


namespace ReportTests
{
    public class ReportServiceTests
    {
        private readonly Mock<ITransactionService> _mockTransactionService;
        private readonly ReportService _reportService;

        public ReportServiceTests()
        {
            // Configura o mock do ITransactionService
            _mockTransactionService = new Mock<ITransactionService>();
            _reportService = new ReportService(_mockTransactionService.Object);
        }

        [Fact]
        public void GetDailyBalance_WithCreditTransactions_ReturnsCorrectBalance()
        {
            // Arrange
            var date = DateTime.Today;
            var transactions = new List<Transaction>
            {
                new Transaction { Type = "Credit", Amount = 100, Date = date },
                new Transaction { Type = "Credit", Amount = 50, Date = date }
            };
            _mockTransactionService.Setup(s => s.GetTransactions(date)).Returns(transactions);

            // Act
            var balance = _reportService.GetDailyBalance(date);

            // Assert
            Assert.Equal(150, balance);
        }

        [Fact]
        public void GetDailyBalance_WithDebitTransactions_ReturnsCorrectBalance()
        {
            // Arrange
            var date = DateTime.Today;
            var transactions = new List<Transaction>
            {
                new Transaction { Type = "Debit", Amount = 100, Date = date },
                new Transaction { Type = "Debit", Amount = 50, Date = date }
            };
            _mockTransactionService.Setup(s => s.GetTransactions(date)).Returns(transactions);

            // Act
            var balance = _reportService.GetDailyBalance(date);

            // Assert
            Assert.Equal(-150, balance);
        }

        [Fact]
        public void GetDailyBalance_WithMixedTransactions_ReturnsCorrectBalance()
        {
            // Arrange
            var date = DateTime.Today;
            var transactions = new List<Transaction>
            {
                new Transaction { Type = "Credit", Amount = 100, Date = date },
                new Transaction { Type = "Debit", Amount = 50, Date = date },
                new Transaction { Type = "Credit", Amount = 30, Date = date }
            };
            _mockTransactionService.Setup(s => s.GetTransactions(date)).Returns(transactions);

            // Act
            var balance = _reportService.GetDailyBalance(date);

            // Assert
            Assert.Equal(80, balance); // 100 - 50 + 30 = 80
        }

        [Fact]
        public void GetDailyBalance_NoTransactions_ReturnsZero()
        {
            // Arrange
            var date = DateTime.Today;
            var transactions = new List<Transaction>(); // Empty list
            _mockTransactionService.Setup(s => s.GetTransactions(date)).Returns(transactions);

            // Act
            var balance = _reportService.GetDailyBalance(date);

            // Assert
            Assert.Equal(0, balance);
        }
    }
}