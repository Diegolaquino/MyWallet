using Microsoft.AspNetCore.Mvc;
using MyWallet.Domain.Models;
using MyWallet.Services.Contracts;
using MyWallet.Services.Responses;
using MyWallet.Shared.DTO;
using System.Net;
using System.Threading;

namespace MyWallet.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryService _categoryService;
        public CategoriesController(ICategoryService categoryService)
        {
            this._categoryService = categoryService;
        }
        // GET: api/<CategoriesController>
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        [ProducesResponseType(typeof(IEnumerable<CategoryDTO>), (int)HttpStatusCode.NoContent)]
        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery]OwnerParametersDTO filters, CancellationToken cancellationToken)
        {
            var response = await _categoryService.GetAll(filters, cancellationToken);

            return StatusCode(response.StatusCode, response);
        }

        // GET api/<CategoriesController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id, CancellationToken cancellationToken)
        {
            var response = await _categoryService.GetEntity(id, cancellationToken);

            return StatusCode(response.StatusCode, response);
        }

        // POST api/<CategoriesController>
        [ProducesResponseType(typeof(SucessResponse<CategoryDTO>), (int)HttpStatusCode.Created)]
        [ProducesResponseType(typeof(FailureResponse), (int)HttpStatusCode.BadRequest)]
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CategoryEntryDTO requestCategory, CancellationToken cancellationToken)
        {
            var category = await _categoryService.Save(requestCategory, cancellationToken);

            return StatusCode(category.StatusCode, category);
        }

        // PUT api/<CategoriesController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put([FromBody] CategoryEntryDTO value, CancellationToken cancellationToken)
        {
            await _categoryService.UpdateAsync(value, cancellationToken);

            return Ok();
        }

        // DELETE api/<CategoriesController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            await _categoryService.DeleteAsync(id);

            return NoContent();
        }
    }
}
