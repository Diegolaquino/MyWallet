using MyWallet.Domain.Models;
using System.Threading;

namespace MyWallet.Repositories.Contracts
{
    public interface IExpenseRepository : IRepositoryBase<Expense>
    {
        Task<IEnumerable<Expense>> GetByDateInterval(DateTime start, DateTime end, CancellationToken cancellationToken);

        Task<IEnumerable<FixedEntry>> GetFixedEntriesActivesAsync(CancellationToken cancellationToken);

        Task<Balance> GetBalanceAsync(int month, int year, CancellationToken cancellationToken);
    }
}
