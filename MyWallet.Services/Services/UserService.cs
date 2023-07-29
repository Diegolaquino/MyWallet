using AutoMapper;
using MyWallet.Domain.Models;
using MyWallet.Repositories.Base;
using MyWallet.Repositories.Contracts;
using MyWallet.Services.Contracts;
using MyWallet.Services.Responses;
using MyWallet.Shared.DTO;
using System.Net;

namespace MyWallet.Services.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        private readonly IUoW _uoW;
        public UserService(IUserRepository userRepository, IMapper mapper, IUoW uoW)
        {
            _userRepository = userRepository;
            _mapper = mapper;
            _uoW = uoW;
        }

        public async Task<ResponseBase> CreateUser(CreateUserDTO userDTO, CancellationToken cancellationToken)
        {
            if (!CheckPassword(userDTO.Password, userDTO.PasswordCopy))
                return new FailureResponse((int)HttpStatusCode.BadRequest, "Passwords must be the same");

            var user = _mapper.Map<User>(userDTO);
            var createdUser = await _userRepository.AddAsync(user, cancellationToken);
            await _uoW.CommitAsync();

            return new SucessResponse<UserDTO>((int)HttpStatusCode.Created, _mapper.Map<UserDTO>(createdUser));
        }

        public bool CheckPassword(string password, string passwordCopy) => password == passwordCopy;
       
    }
}
