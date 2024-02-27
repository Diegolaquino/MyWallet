using Microsoft.AspNetCore.Mvc;
using MyWallet.Services.Contracts;
using MyWallet.Services.Responses;
using MyWallet.Shared.DTO;
using System.Net;

namespace MyWallet.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExercisesController : ControllerBase
    {
        private readonly IExerciseService _exerciseService;

        public ExercisesController(IExerciseService exerciseService)
        {
            _exerciseService = exerciseService;
        }

        // GET: api/<ExercisesController>
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        [ProducesResponseType(typeof(IEnumerable<ExerciseDTO>), (int)HttpStatusCode.OK)]
        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] OwnerParametersDTO filters, CancellationToken cancellationToken)
        {
            var response = await _exerciseService.GetAll(filters, cancellationToken);

            return StatusCode(response.StatusCode, response);
        }

        // GET api/<ExercisesController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id, CancellationToken cancellationToken)
        {
            var response = await _exerciseService.GetEntityAsync(id, cancellationToken);

            return StatusCode(response.StatusCode, response);
        }

        // POST api/<ExercisesController>
        [ProducesResponseType(typeof(SucessResponse<ExerciseDTO>), (int)HttpStatusCode.Created)]
        [ProducesResponseType(typeof(FailureResponse), (int)HttpStatusCode.BadRequest)]
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] ExerciseDTO requestExercise, CancellationToken cancellationToken)
        {
            var response = await _exerciseService.SaveAsync(requestExercise, cancellationToken);

            return StatusCode(response.StatusCode, response);
        }

        // PUT api/<ExercisesController>/5
        [HttpPut]
        public async Task<IActionResult> Put([FromBody] ExerciseDTO exercise, CancellationToken cancellationToken)
        {
            await _exerciseService.UpdateAsync(exercise, cancellationToken);

            return Ok();
        }

        // DELETE api/<ExercisesController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            await _exerciseService.DeleteAsync(id);

            return NoContent();
        }

        // GET api/<ExercisesController>/bydateinterval
        [HttpGet("bydateinterval")]
        public async Task<IActionResult> GetInterval([FromQuery] IntervalDTO exerciseInterval, CancellationToken cancellationToken)
        {
            var response = await _exerciseService.GetExerciseByIntervalAsync(exerciseInterval, cancellationToken);

            return StatusCode(response.StatusCode, response);
        }
    }
}
