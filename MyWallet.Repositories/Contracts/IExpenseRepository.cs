using MyWallet.Domain.Models;

namespace MyWallet.Repositories.Contracts
{
    public interface IExpenseRepository : IRepositoryBase<Expense>
    {
        Task<IEnumerable<Expense>> GetByDateInterval(DateTime start, DateTime end, CancellationToken cancellationToken);
    }
}
