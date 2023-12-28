using Microsoft.EntityFrameworkCore;
using MyWallet.Data;
using MyWallet.Domain.Models;
using MyWallet.Repositories.Contracts;
using MyWallet.Shared.DTO;

namespace MyWallet.Repositories.Repositories
{
    public class ExerciseRepository : IExerciseRepository
    {
        private readonly ApplicationContext _context;

        public ExerciseRepository(ApplicationContext context)
        {
            _context = context;
        }

        public async Task<Exercise> AddAsync(Exercise entity, CancellationToken cancellationToken)
        {
            await _context.AddAsync(entity, cancellationToken);
            return entity;
        }

        public async Task DeleteAsync(Guid id)
        {
            var obj = await _context.Set<Exercise>().FindAsync(id);

            if (obj is null)
                return;

            _context.Entry(obj).State = EntityState.Deleted;
        }

        public async Task<IEnumerable<Exercise>> GetAllAsync(OwnerParametersDTO ownerParameters, CancellationToken cancellationToken)
        {
            var exercises = await _context.Exercises.OrderBy(on => on.CreatedDate)
                    .Skip((ownerParameters.PageNumber - 1) * ownerParameters.PageSize)
                    .Take(ownerParameters.PageSize).AsNoTracking().ToListAsync(cancellationToken);

            return exercises;
        }

        public async Task<Exercise> GetByIdAsync(Guid id, CancellationToken cancellationToken)
        {
            var obj = await _context.Set<Exercise>().FindAsync(id, cancellationToken);
            return obj;
        }

        public async Task UpdateAsync(Exercise entity, CancellationToken cancellationToken)
        {
            entity.UpdateDate();
            _context.Entry(entity).State = EntityState.Modified;
        }

        public async Task<IEnumerable<Exercise>> GetByDateInterval(DateTime start, DateTime end, CancellationToken cancellationToken)
        {
            var exerciseSet = await _context.Exercises
                   .Where(e => e.CreatedDate.Date >= start.Date && e.CreatedDate.Date <= end.Date)
                   .AsNoTracking().ToListAsync(cancellationToken);

            return exerciseSet;
        }
    }

}
