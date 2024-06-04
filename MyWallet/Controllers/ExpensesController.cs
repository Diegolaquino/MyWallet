using Microsoft.AspNetCore.Mvc;
using MyWallet.Services.Contracts;
using MyWallet.Services.Responses;
using MyWallet.Shared.DTO;
using System.Net;

namespace MyWallet.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExpensesController : ControllerBase
    {
        private readonly IExpenseService _expenseService;
        public ExpensesController(IExpenseService expenseService)
        {
            _expenseService = expenseService;
        }

        // GET: api/<ExpensesController>
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        [ProducesResponseType(typeof(IEnumerable<ExpenseDTO>), (int)HttpStatusCode.NoContent)]
        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] OwnerParametersDTO filters, CancellationToken cancellationToken)
        {
            var response = await _expenseService.GetAll(filters, cancellationToken);

            return StatusCode(response.StatusCode, response);
        }

        // GET api/<ExpensesController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id, CancellationToken cancellationToken)
        {
            var response = await _expenseService.GetEntityAsync(id, cancellationToken);

            return StatusCode(response.StatusCode, response);
        }

        // POST api/<ExpensesController>
        [ProducesResponseType(typeof(SucessResponse<ExpenseDTO>), (int)HttpStatusCode.Created)]
        [ProducesResponseType(typeof(FailureResponse), (int)HttpStatusCode.BadRequest)]
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] ExpenseEntryDTO requestExpense, CancellationToken cancellationToken)
        {
            var expense = await _expenseService.SaveAsync(requestExpense, cancellationToken);

            return StatusCode(expense.StatusCode, expense);
        }

        // PUT api/<ExpensesController>/5
        [HttpPut]
        public async Task<IActionResult> Put([FromBody] ExpenseEntryDTO value, CancellationToken cancellationToken)
        {
            await _expenseService.UpdateAsync(value, cancellationToken);

            return Ok();
        }

        // DELETE api/<ExpensesController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            await _expenseService.DeleteAsync(id);

            return NoContent();
        }

        // GET api/<ExpensesController>/5
        [HttpGet("bydateinterval")]
        public async Task<IActionResult> GetInterval([FromQuery]IntervalDTO expenseInterval, CancellationToken cancellationToken)
        {
            var response = await _expenseService.GetExpensesByInterval(expenseInterval, cancellationToken);

            return StatusCode(response.StatusCode, response);
        }

        // GET api/<ExpensesController>/5
        [HttpGet("Balance")]
        public async Task<IActionResult> GetBalance([FromQuery] int month, [FromQuery] int year, CancellationToken cancellationToken)
        {
            var response = await _expenseService.GetBalanceAsync(month, year, cancellationToken);

            return StatusCode(response.StatusCode, response);
        }
    }
}
