using Microsoft.AspNetCore.Mvc;
using MyWallet.Services.Contracts;

namespace MyWallet.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FixedEntriesController : ControllerBase
    {
        private readonly IExpenseService _expenseService;

        public FixedEntriesController(IExpenseService expenseService)
        {
            _expenseService = expenseService;
        }

        // GET api/<ExpensesController>/5
        [HttpGet]
        public async Task<IActionResult> GetFixedEntries(CancellationToken cancellationToken)
        {
            var response = await _expenseService.GetFixedEntriesAsync(cancellationToken);

            return StatusCode(response.StatusCode, response);
        }
    }
}
