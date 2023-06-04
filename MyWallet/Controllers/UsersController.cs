using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyWallet.Services.Contracts;
using MyWallet.Shared.DTO;

namespace MyWallet.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;
        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateUser(CreateUserDTO userDTO)
        {
            if (userDTO is null)
                return BadRequest("Os dados devem ser preenchidos para criação de usuário.");

            var user = await _userService.CreateUser(userDTO);

            return StatusCode(user.StatusCode, user);
        }
    }
}
