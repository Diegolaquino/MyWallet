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
    public class IncomesController : ControllerBase
    {
        private readonly IIncomeService _incomeService;
        public IncomesController(IIncomeService incomeService)
        {
            _incomeService = incomeService;
        }

        // GET: api/<IncomesController>
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        [ProducesResponseType(typeof(IEnumerable<IncomeDTO>), (int)HttpStatusCode.NoContent)]
        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] OwnerParametersDTO filters, CancellationToken cancellationToken)
        {
            var response = await _incomeService.GetAll(filters, cancellationToken);

            return StatusCode(response.StatusCode, response);
        }

        // GET api/<IncomesController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id, CancellationToken cancellationToken)
        {
            var response = await _incomeService.GetEntity(id, cancellationToken);

            return StatusCode(response.StatusCode, response);
        }

        // POST api/<IncomesController>
        [ProducesResponseType(typeof(SucessResponse<IncomeDTO>), (int)HttpStatusCode.Created)]
        [ProducesResponseType(typeof(FailureResponse), (int)HttpStatusCode.BadRequest)]
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] IncomeEntryDTO requestIncome, CancellationToken cancellationToken)
        {
            var income = await _incomeService.Save(requestIncome, cancellationToken);

            return StatusCode(income.StatusCode, income);
        }

        // PUT api/<IncomesController>/5
        [HttpPut]
        public async Task<IActionResult> Put([FromBody] IncomeEntryDTO value, CancellationToken cancellationToken)
        {
            await _incomeService.UpdateAsync(value, cancellationToken);

            return Ok();
        }

        // DELETE api/<IncomesController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            await _incomeService.DeleteAsync(id);

            return NoContent();
        }
    }
}
