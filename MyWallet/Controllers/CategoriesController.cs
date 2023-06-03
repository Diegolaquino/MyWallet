using Microsoft.AspNetCore.Mvc;
using MyWallet.Services.Contracts;
using MyWallet.Shared.DTO;
using System.Net;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

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
        public async Task<IActionResult> Get([FromQuery]OwnerParametersDTO filters)
        {
            var categories = await _categoryService.GetAll(filters);

            if (!categories.Any())
                return NoContent();

            return Ok(categories);
        }

        // GET api/<CategoriesController>/5
        //[HttpGet("{id}")]
        //public string Get(int id)
        //{
        //    return "value";
        //}

        // POST api/<CategoriesController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CategoryDTO requestCategory)
        {
            if (requestCategory is null)
                return BadRequest("objeto nulo");

            var category = await _categoryService.Save(requestCategory);

            return Ok(category);
        }

        //// PUT api/<CategoriesController>/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody] string value)
        //{
        //}

        //// DELETE api/<CategoriesController>/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}
    }
}
