using Microsoft.EntityFrameworkCore;
using MyWallet.Data;
using MyWallet.Domain.Models;
using MyWallet.Repositories.Contracts;
using MyWallet.Shared.DTO;

namespace MyWallet.Repositories.Repositories
{
    public class WalletRepository : IWalletRepository
    {
        private readonly ApplicationContext _context;

        public WalletRepository(ApplicationContext context)
        {
            _context = context;
        }

        public async Task<Wallet> AddAsync(Wallet entity, CancellationToken cancellationToken)
        {
            await _context.AddAsync(entity, cancellationToken);

            return entity;
        }

        public async Task DeleteAsync(Guid id)
        {
            var obj = await _context.Set<Wallet>().FindAsync(id);

            if (obj is null)
                return;

            _context.Entry(obj).State = EntityState.Deleted;
        }

        public async Task<IEnumerable<Wallet>> GetAllAsync(OwnerParametersDTO ownerParameters, CancellationToken cancellationToken)
        {
            var wallets = await _context.Wallets.OrderBy(on => on.CreatedDate)
                    .Skip((ownerParameters.PageNumber - 1) * ownerParameters.PageSize)
                    .Take(ownerParameters.PageSize).AsNoTracking().ToListAsync(cancellationToken);

            return wallets;
        }

        public async Task<Wallet> GetByIdAsync(Guid id, CancellationToken cancellationToken)
        {
            var obj = await _context.Set<Wallet>().FindAsync(id, cancellationToken);
            return obj;
        }

        public async Task UpdateAsync(Wallet entity, CancellationToken cancellationToken)
        {
            entity.UpdateDate();
            _context.Entry(entity).State = EntityState.Modified;
        }
    }
}
