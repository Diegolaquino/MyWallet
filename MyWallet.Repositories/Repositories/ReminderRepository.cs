using Microsoft.EntityFrameworkCore;
using MyWallet.Data;
using MyWallet.Domain.Models;
using MyWallet.Repositories.Contracts;
using MyWallet.Shared.DTO;

namespace MyWallet.Repositories.Repositories
{
    public class ReminderRepository : IReminderRepository
    {
        private readonly ApplicationContext _context;
        public ReminderRepository(ApplicationContext context)
        {
            _context = context;
        }

        public async Task<Reminder> GetByIdAsync(Guid id, CancellationToken cancellationToken)
        {
            var obj = await _context.Set<Reminder>().FindAsync(id);
            return obj;
        }

        public async Task UpdateAsync(Reminder entity, CancellationToken cancellationToken)
        {
            entity.UpdateDate();
            _context.Entry(entity).State = EntityState.Modified;
        }

        public async Task DeleteAsync(Guid id)
        {
            var obj = await _context.Set<Reminder>().FindAsync(id);

            if (obj is null)
                return;

            _context.Entry(obj).State = EntityState.Deleted;
        }

        public async Task<Reminder> AddAsync(Reminder reminder, CancellationToken cancellationToken)
        {
            await _context.AddAsync(reminder, cancellationToken);

            return reminder;
        }

        public async Task<IEnumerable<Reminder>> GetAllAsync(OwnerParametersDTO ownerParameters, CancellationToken cancellationToken)
        {
            var reminders = await _context.Reminders.OrderBy(on => on.Name)
                    .Skip((ownerParameters.PageNumber - 1) * ownerParameters.PageSize)
                    .Take(ownerParameters.PageSize).AsNoTracking().ToListAsync(cancellationToken);

            return reminders;
        }
    }
}
