using MyWallet.Domain.Models;

namespace MyWallet.Repositories.Contracts
{
    public interface IReminderRepository : IRepositoryBase<Reminder>
    {
        public Task<List<Reminder>> GetRemindersNoResolvedAsync(CancellationToken cancellationToken);
    }
}
