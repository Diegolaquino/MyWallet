using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyWallet.Services.Contracts;
using MyWallet.Services.Responses;
using MyWallet.Shared.DTO;
using System.Net;

namespace MyWallet.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HealthController : ControllerBase
    {
        private readonly IHealthService _healthService;
        public HealthController(IHealthService healthService)
        {
            _healthService = healthService;
        }

        // GET: api/<ExpensesController>
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        [ProducesResponseType(typeof(IEnumerable<HealthDTO>), (int)HttpStatusCode.NoContent)]
        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] OwnerParametersDTO filters, CancellationToken cancellationToken)
        {
            var response = await _healthService.GetAll(filters, cancellationToken);

            return StatusCode(response.StatusCode, response);
        }

        // GET api/<ExpensesController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id, CancellationToken cancellationToken)
        {
            var response = await _healthService.GetEntity(id, cancellationToken);

            return StatusCode(response.StatusCode, response);
        }

        // POST api/<ExpensesController>
        [ProducesResponseType(typeof(SucessResponse<HealthDTO>), (int)HttpStatusCode.Created)]
        [ProducesResponseType(typeof(FailureResponse), (int)HttpStatusCode.BadRequest)]
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] ExpenseEntryDTO requestExpense, CancellationToken cancellationToken)
        {
            var expense = await _healthService.Save(requestExpense, cancellationToken);

            return StatusCode(expense.StatusCode, expense);
        }

        // PUT api/<ExpensesController>/5
        [HttpPut]
        public async Task<IActionResult> Put([FromBody] ExpenseEntryDTO value, CancellationToken cancellationToken)
        {
            await _healthService.UpdateAsync(value, cancellationToken);

            return Ok();
        }

        // DELETE api/<ExpensesController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            await _healthService.DeleteAsync(id);

            return NoContent();
        }

        // GET api/<ExpensesController>/5
        [HttpGet("bydateinterval")]
        public async Task<IActionResult> GetInterval([FromQuery] ExpenseIntervalDTO expenseInterval, CancellationToken cancellationToken)
        {
            var response = await _healthService.GetExpensesByInterval(expenseInterval, cancellationToken);

            return StatusCode(response.StatusCode, response);
        }
    }
}
