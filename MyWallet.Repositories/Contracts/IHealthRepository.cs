using MyWallet.Domain.Models;

namespace MyWallet.Repositories.Contracts
{
    public interface IHealthRepository : IRepositoryBase<Health>
    {
        Task<IEnumerable<Health>> GetByDateInterval(DateTime start, DateTime end, CancellationToken cancellationToken);
    }
}
