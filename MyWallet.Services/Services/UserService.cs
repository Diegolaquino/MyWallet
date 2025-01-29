using AutoMapper;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using MyWallet.Domain.Models;
using MyWallet.Repositories.Base;
using MyWallet.Repositories.Contracts;
using MyWallet.Services.Contracts;
using MyWallet.Services.Responses;
using MyWallet.Shared.DTO;
using System.IdentityModel.Tokens.Jwt;
using System.Net;
using System.Security.Claims;
using System.Text;

namespace MyWallet.Services.Services
{
    public class UserService : IUserService
    {
        private IConfiguration _config;
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<UserService> _logger;
        private readonly IUoW _unitOfWork;

        public UserService(IConfiguration configuration, IUserRepository userRepository, IMapper mapper, ILogger<UserService> logger, IUoW unitOfWork)
        {
            _config = configuration;
            _userRepository = userRepository;
            _mapper = mapper;
            _logger = logger;
            _unitOfWork = unitOfWork;
        }

        public string GenerateToken(UserDTO user)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new[]
            {
            new Claim(JwtRegisteredClaimNames.Sub, user.UserName),
            new Claim(JwtRegisteredClaimNames.Email, user.Email),
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
        };

            var token = new JwtSecurityToken(
                issuer: _config["Jwt:Issuer"],
                audience: _config["Jwt:Audience"],
                claims: claims,
                expires: DateTime.Now.AddMinutes(30),
                signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        public User Authenticate(UserLoginDTO userLogin)
        {
            if (userLogin.UserName == "user" && userLogin.Password == "password")
            {
                return new User { UserName = "user", Email = "user@example.com" };
            }

            return null;
        }

        public async Task<ResponseBase> CreateUser(CreateUserDTO userDTO, CancellationToken cancellationToken)
        {
            var user = await _userRepository.AddAsync(_mapper.Map<User>(userDTO), cancellationToken);

            await _unitOfWork.CommitAsync();

            return new SucessResponse<UserDTO>((int)HttpStatusCode.Created, _mapper.Map<UserDTO>(user));
        }
    }
}
