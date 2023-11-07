using Microsoft.EntityFrameworkCore;
using MyWallet.Data;
using MyWallet.Domain.Models;
using MyWallet.Repositories.Contracts;
using MyWallet.Shared.DTO;

namespace MyWallet.Repositories.Repositories
{
    public class IncomeRepository : IIncomeRepository
    {
        private readonly ApplicationContext _context;
        public IncomeRepository(ApplicationContext context)
        {
            _context = context;
        }
        public async Task<Income> AddAsync(Income entity, CancellationToken cancellationToken)
        {
            await _context.AddAsync(entity, cancellationToken);

            return entity;
        }

        public async Task DeleteAsync(Guid id)
        {
            var obj = await _context.Set<Income>().FindAsync(id);

            if (obj is null)
                return;

            _context.Entry(obj).State = EntityState.Deleted;
        }

        public async Task<IEnumerable<Income>> GetAllAsync(OwnerParametersDTO ownerParameters, CancellationToken cancellationToken)
        {
            var incomes = await _context.Incomes.Include(i => i.Category).Include(c => c.Wallet).OrderBy(on => on.CreatedDate)
                    .Skip((ownerParameters.PageNumber - 1) * ownerParameters.PageSize)
                    .Take(ownerParameters.PageSize).AsNoTracking().ToListAsync(cancellationToken);

            return incomes;
        }

        public async Task<Income> GetByIdAsync(Guid id, CancellationToken cancellationToken)
        {

            var obj = await _context.Set<Income>().FindAsync(id, cancellationToken);
            return obj;
        }

        public async Task UpdateAsync(Income entity, CancellationToken cancellationToken)
        {
            entity.UpdateDate();
            _context.Entry(entity).State = EntityState.Modified;
        }

        public async Task<IEnumerable<Income>> GetByDateInterval(DateTime start, DateTime end, CancellationToken cancellationToken)
        {
            var incomes = await _context.Incomes
                   .Where(e => e.IncomeDate.Date >= start.Date && e.IncomeDate.Date <= end.Date).Include(i => i.Category).Select(e => new Income
                   {
                       IncomeDate = e.IncomeDate,
                       Value = e.Value,
                       WalletId = e.WalletId,
                       Wallet = e.Wallet,
                       WalletName = e.Wallet == null ? null : e.Wallet.Name,
                       CategoryId = e.CategoryId,
                       Category = e.Category,
                       CategoryName = e.Category == null ? null : e.Category.Name,
                       Tags = e.Tags,
                       InstallmentsQuantity = e.InstallmentsQuantity,
                       Comments = e.Comments,
                       Installment = e.Installment
                   }).AsNoTracking().ToListAsync(cancellationToken);

            return incomes;
        }
    }
}
