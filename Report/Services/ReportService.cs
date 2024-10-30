using Transactions.Services;

namespace Report.Services
{
    public class ReportService
    {
        private readonly ITransactionService _transactionService;

        public ReportService(ITransactionService transactionService)
        {
            _transactionService = transactionService;
        }

        public decimal GetDailyBalance(DateTime date)
        {
            var transactions = _transactionService.GetTransactions(date);
            return transactions.Sum(t => t.Type == "Credit" ? t.Amount : -t.Amount);
        }
    }
}
