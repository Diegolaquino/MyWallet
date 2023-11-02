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
    public class TagsController : ControllerBase
    {
        private readonly ITagService _tagService;
        public TagsController(ITagService tagService)
        {
            this._tagService = tagService;
        }
        // GET: api/<TagsController>
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        [ProducesResponseType(typeof(IEnumerable<TagDTO>), (int)HttpStatusCode.NoContent)]
        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] OwnerParametersDTO filters, CancellationToken cancellationToken)
        {
            var response = await _tagService.GetAll(filters, cancellationToken);

            return StatusCode(response.StatusCode, response);
        }

        // GET api/<TagsController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id, CancellationToken cancellationToken)
        {
            var response = await _tagService.GetEntity(id, cancellationToken);

            return StatusCode(response.StatusCode, response);
        }

        // POST api/<TagsController>
        [ProducesResponseType(typeof(SucessResponse<TagDTO>), (int)HttpStatusCode.Created)]
        [ProducesResponseType(typeof(FailureResponse), (int)HttpStatusCode.BadRequest)]
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] TagDTO requestTag, CancellationToken cancellationToken)
        {
            var tag = await _tagService.Save(requestTag, cancellationToken);

            return StatusCode(tag.StatusCode, tag);
        }

        // PUT api/<TagsController>/5
        [HttpPut]
        public async Task<IActionResult> Put([FromBody] TagDTO value, CancellationToken cancellationToken)
        {
            await _tagService.UpdateAsync(value, cancellationToken);

            return Ok();
        }

        // DELETE api/<TagsController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            await _tagService.DeleteAsync(id);

            return NoContent();
        }
    }
}
