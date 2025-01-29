using MyWallet.Domain.Models;
using MyWallet.Services.Responses;
using MyWallet.Shared.DTO;

namespace MyWallet.Services.Contracts
{
    public interface IUserService
    {
        Task<ResponseBase> CreateUser(CreateUserDTO userDTO, CancellationToken cancellationToken);

        string GenerateToken(UserDTO user);

        User Authenticate(UserLoginDTO userLogin);
    }
}
