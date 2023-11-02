using Microsoft.EntityFrameworkCore;
using MyWallet.Data;
using MyWallet.Domain.Models;
using MyWallet.Repositories.Contracts;
using MyWallet.Shared.DTO;

namespace MyWallet.Repositories.Repositories
{
    public class ExpenseRepository : IExpenseRepository
    {
        private readonly ApplicationContext _context;
        public ExpenseRepository(ApplicationContext context)
        {
            _context = context;
        }

        public async Task<Expense> GetByIdAsync(Guid id, CancellationToken cancellationToken)
        {
            var obj = await _context.Set<Expense>().FindAsync(id, cancellationToken);
            return obj;
        }

        public async Task UpdateAsync(Expense entity, CancellationToken cancellationToken)
        {
            entity.UpdateDate();
            _context.Entry(entity).State = EntityState.Modified;
        }

        public async Task DeleteAsync(Guid id)
        {
            var obj = await _context.Set<Expense>().FindAsync(id);

            if (obj is null)
                return;

            _context.Entry(obj).State = EntityState.Deleted;
        }

        public async Task<Expense> AddAsync(Expense expense, CancellationToken cancellationToken)
        {
            await _context.AddAsync(expense, cancellationToken);

            return expense;
        }

        public async Task<IEnumerable<Expense>> GetAllAsync(OwnerParametersDTO ownerParameters, CancellationToken cancellationToken)
        {
            var expenses = await _context.Expenses.Include(x => x.Category).OrderBy(on => on.CreatedDate)
                    .Skip((ownerParameters.PageNumber - 1) * ownerParameters.PageSize)
                    .Take(ownerParameters.PageSize).AsNoTracking().ToListAsync(cancellationToken);

            return expenses;
        }

        public async Task<IEnumerable<Expense>> GetByDateInterval(DateTime start, DateTime end, CancellationToken cancellationToken)
        {
            var expenses = await _context.Expenses
                   .Where(e => e.ExpenseDate >= start && e.ExpenseDate <= end).Include(e => e.Category).AsNoTracking().ToListAsync(cancellationToken);

            return expenses;
        }
    }
}
