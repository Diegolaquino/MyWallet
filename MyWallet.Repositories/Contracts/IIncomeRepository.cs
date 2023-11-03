using MyWallet.Domain.Models;

namespace MyWallet.Repositories.Contracts
{
    public interface IIncomeRepository : IRepositoryBase<Income>
    {
        Task<IEnumerable<Income>> GetByDateInterval(DateTime start, DateTime end, CancellationToken cancellationToken);
    }
}
