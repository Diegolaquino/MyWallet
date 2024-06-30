using Microsoft.EntityFrameworkCore.SqlServer.Query.Internal;
using MyWallet.Services.Responses;
using MyWallet.Shared.DTO;

namespace MyWallet.Services.Contracts
{
    public interface IWalletService : IBaseService<WalletDTO>
    {
        Task<ResponseBase> GetWalletValueAsync(int month, int year, CancellationToken cancellationToken);
    }
}
