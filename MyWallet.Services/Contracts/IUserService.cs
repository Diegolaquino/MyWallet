using MyWallet.Services.Responses;
using MyWallet.Shared.DTO;

namespace MyWallet.Services.Contracts
{
    public interface IUserService
    {
        Task<ResponseBase> CreateUser(CreateUserDTO userDTO, CancellationToken cancellationToken);
    }
}
