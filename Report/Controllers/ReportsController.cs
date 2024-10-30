using Microsoft.AspNetCore.Mvc;
using Report.Services;

namespace Report.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ReportsController : ControllerBase
    {
        private readonly ReportService _reportService;

        public ReportsController(ReportService reportService)
        {
            _reportService = reportService;
        }

        [HttpGet("{date}")]
        public ActionResult<decimal> GetDailyBalance(DateTime date)
        {
            var balance = _reportService.GetDailyBalance(date);
            return Ok(balance);
        }
    }
}
