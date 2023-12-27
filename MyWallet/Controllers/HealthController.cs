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

        // GET: api/<HealthController>
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        [ProducesResponseType(typeof(IEnumerable<HealthDTO>), (int)HttpStatusCode.NoContent)]
        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] OwnerParametersDTO filters, CancellationToken cancellationToken)
        {
            var response = await _healthService.GetAll(filters, cancellationToken);

            return StatusCode(response.StatusCode, response);
        }

        // GET api/<HealthController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id, CancellationToken cancellationToken)
        {
            var response = await _healthService.GetEntityAsync(id, cancellationToken);

            return StatusCode(response.StatusCode, response);
        }

        // POST api/<HealthController>
        [ProducesResponseType(typeof(SucessResponse<HealthDTO>), (int)HttpStatusCode.Created)]
        [ProducesResponseType(typeof(FailureResponse), (int)HttpStatusCode.BadRequest)]
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] HealthDTO requestExpense, CancellationToken cancellationToken)
        {
            var expense = await _healthService.SaveAsync(requestExpense, cancellationToken);

            return StatusCode(expense.StatusCode, expense);
        }

        // PUT api/<HealthController>/5
        [HttpPut]
        public async Task<IActionResult> Put([FromBody] HealthDTO value, CancellationToken cancellationToken)
        {
            await _healthService.UpdateAsync(value, cancellationToken);

            return Ok();
        }

        // DELETE api/<HealthController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            await _healthService.DeleteAsync(id);

            return NoContent();
        }

        // GET api/<HealthController>/5
        [HttpGet("bydateinterval")]
        public async Task<IActionResult> GetInterval([FromQuery] IntervalDTO expenseInterval, CancellationToken cancellationToken)
        {
            var response = await _healthService.GetHealthByIntervalAsync(expenseInterval, cancellationToken);

            return StatusCode(response.StatusCode, response);
        }
    }
}
