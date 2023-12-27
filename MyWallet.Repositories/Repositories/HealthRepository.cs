using Microsoft.EntityFrameworkCore;
using MyWallet.Data;
using MyWallet.Domain.Models;
using MyWallet.Repositories.Contracts;
using MyWallet.Shared.DTO;

namespace MyWallet.Repositories.Repositories
{
    public class HealthRepository : IHealthRepository
    {
        private readonly ApplicationContext _context;
        public HealthRepository(ApplicationContext context)
        {
            _context = context;
        }

        public async Task<Health> AddAsync(Health entity, CancellationToken cancellationToken)
        {
            await _context.AddAsync(entity, cancellationToken);

            return entity;
        }

        public async Task DeleteAsync(Guid id)
        {
            var obj = await _context.Set<Health>().FindAsync(id);

            if (obj is null)
                return;

            _context.Entry(obj).State = EntityState.Deleted;
        }

        public async Task<IEnumerable<Health>> GetAllAsync(OwnerParametersDTO ownerParameters, CancellationToken cancellationToken)
        {
            var heaths = await _context.Healths.OrderBy(on => on.CreatedDate)
                    .Skip((ownerParameters.PageNumber - 1) * ownerParameters.PageSize)
                    .Take(ownerParameters.PageSize).AsNoTracking().ToListAsync(cancellationToken);

            return heaths;
        }

        public async Task<Health> GetByIdAsync(Guid id, CancellationToken cancellationToken)
        {
            var obj = await _context.Set<Health>().FindAsync(id, cancellationToken);
            return obj;
        }

        public async Task UpdateAsync(Health entity, CancellationToken cancellationToken)
        {
            entity.UpdateDate();
            _context.Entry(entity).State = EntityState.Modified;
        }

        public async Task<IEnumerable<Health>> GetByDateInterval(DateTime start, DateTime end, CancellationToken cancellationToken)
        {
            var healthSet = await _context.Healths
                   .Where(e => e.CreatedDate.Date >= start.Date && e.CreatedDate.Date <= end.Date)
                   .AsNoTracking().ToListAsync(cancellationToken);

            return healthSet;
        }

    }
}
