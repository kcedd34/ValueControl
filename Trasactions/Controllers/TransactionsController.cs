using Microsoft.AspNetCore.Mvc;
using Transactions.Models;
using Transactions.Services;

namespace Transactions.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TransactionsController : ControllerBase
    {
        private readonly ITransactionService _transactionService;

        public TransactionsController(ITransactionService transactionService)
        {
            _transactionService = transactionService;
        }

        [HttpPost]
        public IActionResult AddTransaction([FromBody] Transaction transaction)
        {
            _transactionService.AddTransaction(transaction);
            return Ok();
        }

        [HttpGet("{date}")]
        public ActionResult<IEnumerable<Transaction>> GetTransactions(DateTime date)
        {
            var transactions = _transactionService.GetTransactions(date);
            return Ok(transactions);
        }
    }
   
}
