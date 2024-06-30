using MyWallet.Domain.Models;

namespace MyWallet.Repositories.Contracts
{
    public interface IWalletRepository : IRepositoryBase<Wallet>
    {
        Task<IEnumerable<WalletMonth>> GetWalletMonthAsync(int month, int year, int type, CancellationToken cancellationToken);
    }
}
