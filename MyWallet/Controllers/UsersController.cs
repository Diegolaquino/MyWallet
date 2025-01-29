using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using MyWallet.Domain.Models;
using MyWallet.Services.Contracts;
using MyWallet.Shared.DTO;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

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

        //[AllowAnonymous]
        //[HttpPost("login")]
        //public IActionResult Login([FromBody] UserLoginDTO userLogin)
        //{
        //    var user = Authenticate(userLogin);

        //    if (user != null)
        //    {
        //        var token = GenerateToken(user);
        //        return Ok(new { token });
        //    }

        //    return Unauthorized();
        //}
    }
}
