using Microsoft.AspNetCore.Mvc;

namespace MyWallet.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MainController : ControllerBase
    {
        [HttpGet("status")]
        public IActionResult GetApiStatus()
        {
            return Ok(new { message = "Api works..." });
        }

    }
}
