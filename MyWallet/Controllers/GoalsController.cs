using Microsoft.AspNetCore.Mvc;
using MyWallet.Services.Contracts;
using MyWallet.Services.Responses;
using MyWallet.Shared.DTO;
using System.Net;

namespace MyWallet.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GoalsController : ControllerBase
    {
        private readonly IGoalService _goalService;
        public GoalsController(IGoalService goalService)
        {
            _goalService = goalService;
        }

        // GET: api/<GoalsController>
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        [ProducesResponseType(typeof(IEnumerable<GoalDTO>), (int)HttpStatusCode.OK)]
        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] OwnerParametersDTO filters, CancellationToken cancellationToken)
        {
            var response = await _goalService.GetAll(filters, cancellationToken);

            return StatusCode(response.StatusCode, response);
        }

        // POST api/<GoalsController>
        [ProducesResponseType(typeof(SucessResponse<GoalDTO>), (int)HttpStatusCode.Created)]
        [ProducesResponseType(typeof(FailureResponse), (int)HttpStatusCode.BadRequest)]
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] GoalDTO goalRequest, CancellationToken cancellationToken)
        {
            var goal = await _goalService.SaveAsync(goalRequest, cancellationToken);

            return StatusCode(goal.StatusCode, goal);
        }

        // DELETE api/<GoalsController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            await _goalService.DeleteAsync(id);

            return NoContent();
        }
    }
}
