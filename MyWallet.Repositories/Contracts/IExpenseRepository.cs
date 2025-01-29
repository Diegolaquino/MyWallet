using MyWallet.Domain.Models;

namespace MyWallet.Repositories.Contracts
{
    public interface IExpenseRepository : IRepositoryBase<Expense>
    {
        Task<IEnumerable<Expense>> GetByDateInterval(DateTime start, DateTime end, CancellationToken cancellationToken);

        Task<IEnumerable<FixedEntry>> GetFixedEntriesActivesAsync(CancellationToken cancellationToken);

        Task<Balance> GetBalanceAsync(int month, int year, CancellationToken cancellationToken);

        Task<IEnumerable<Expense>> GetExpensesWithInstallmentsAsync(int month, int year, CancellationToken cancellationToken);

        Task<Expense> GetLastExpenseAsync(CancellationToken cancellationToken);
    }

}
