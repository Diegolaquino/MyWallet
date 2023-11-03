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
            var reminder = _context.Reminders.FirstOrDefault(x => x.Name == entity.Name);

            if (reminder is not null)
            {

                reminder.Name = entity.Name;
                reminder.Resolved = entity.Resolved;
                reminder.Comments = entity.Comments ?? reminder.Comments;
            }
            else
            {
                return;
            }

            _context.Entry(reminder).State = EntityState.Modified;
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

        public async Task<List<Reminder>> GetRemindersNoResolvedAsync(CancellationToken cancellationToken)
        {
            var reminders = await _context.Reminders.Where(c => !c.Resolved).AsNoTracking().ToListAsync(cancellationToken);

            return reminders;
        }
    }
}
