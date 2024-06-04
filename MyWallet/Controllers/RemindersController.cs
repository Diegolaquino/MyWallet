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
    public class RemindersController : ControllerBase
    {
        private readonly IReminderService _reminderService;
        public RemindersController(IReminderService reminderService)
        {
            this._reminderService = reminderService;
        }
        //GET: api/<RemindersController>
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        [ProducesResponseType(typeof(IEnumerable<ReminderDTO>), (int)HttpStatusCode.NoContent)]
        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] OwnerParametersDTO filters, CancellationToken cancellationToken)
        {
            var response = await _reminderService.GetAll(filters, cancellationToken);

            return StatusCode(response.StatusCode, response);
        }

        // GET: api/<RemindersController>
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        [ProducesResponseType(typeof(IEnumerable<ReminderDTO>), (int)HttpStatusCode.NoContent)]
        [HttpGet("noResolved")]
        public async Task<IActionResult> GetRemindersActives(CancellationToken cancellationToken)
        {
            var response = await _reminderService.GetRemindersNoResolvedAsync(cancellationToken);

            return StatusCode(response.StatusCode, response);
        }

        // GET api/<RemindersController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id, CancellationToken cancellationToken)
        {
            var response = await _reminderService.GetEntityAsync(id, cancellationToken);

            return StatusCode(response.StatusCode, response);
        }

        // POST api/<RemindersController>
        [ProducesResponseType(typeof(SucessResponse<ReminderDTO>), (int)HttpStatusCode.Created)]
        [ProducesResponseType(typeof(FailureResponse), (int)HttpStatusCode.BadRequest)]
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] ReminderDTO requestReminder, CancellationToken cancellationToken)
        {
            var reminder = await _reminderService.SaveAsync(requestReminder, cancellationToken);

            return StatusCode(reminder.StatusCode, reminder);
        }

        // PUT api/<RemindersController>/5
        [HttpPatch]
        public async Task<IActionResult> Patch([FromBody] ReminderDTO value, CancellationToken cancellationToken)
        {
            await _reminderService.UpdateAsync(value, cancellationToken);

            return Ok();
        }

        // PUT api/<RemindersController>/5
        [HttpPut]
        public async Task<IActionResult> Put([FromBody] ReminderDTO value, CancellationToken cancellationToken)
        {
            await _reminderService.UpdateAsync(value, cancellationToken);

            return Ok();
        }

        // DELETE api/<RemindersController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            await _reminderService.DeleteAsync(id);

            return NoContent();
        }
    }
}
