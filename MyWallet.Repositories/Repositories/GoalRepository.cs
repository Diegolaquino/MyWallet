using Microsoft.EntityFrameworkCore;
using MyWallet.Data;
using MyWallet.Domain.Models;
using MyWallet.Repositories.Contracts;
using MyWallet.Shared.DTO;

namespace MyWallet.Repositories.Repositories
{
    public class GoalRepository : IGoalRepository
    {
        private readonly ApplicationContext _context;

        public GoalRepository(ApplicationContext context)
        {
            _context = context;
        }

        public async Task<Goal> AddAsync(Goal entity, CancellationToken cancellationToken)
        {
            await _context.AddAsync(entity, cancellationToken);

            return entity;
        }

        public async Task DeleteAsync(Guid id)
        {
            var obj = await _context.Set<Goal>().FindAsync(id);

            if (obj is null)
                return;

            _context.Entry(obj).State = EntityState.Deleted;
        }

        public async Task<IEnumerable<Goal>> GetAllAsync(OwnerParametersDTO ownerParameters, CancellationToken cancellationToken)
        {
            var goals = await _context.Goals.Include(x => x.Category)
                   .Skip((ownerParameters.PageNumber - 1) * ownerParameters.PageSize)
                   .Take(ownerParameters.PageSize).AsNoTracking().Select(x =>
                   new Goal()
                   {
                       CategoryId = x.CategoryId,
                       CategoryName = x.Category.Name,
                       Limit = x.Limit,
                       CreatedDate = x.CreatedDate,
                       Name = x.Name,
                   }).ToListAsync(cancellationToken);

            return goals;
        }

        public async Task<Goal> GetByIdAsync(Guid id, CancellationToken cancellationToken)
        {
            var obj = await _context.Set<Goal>().FindAsync(id, cancellationToken);
            return obj;
        }

        public async Task UpdateAsync(Goal entity, CancellationToken cancellationToken)
        {
            entity.UpdateDate();
            _context.Entry(entity).State = EntityState.Modified;
        }
    }
}
