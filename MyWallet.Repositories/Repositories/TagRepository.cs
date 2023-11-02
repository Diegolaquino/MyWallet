using Microsoft.EntityFrameworkCore;
using MyWallet.Data;
using MyWallet.Domain.Models;
using MyWallet.Repositories.Contracts;
using MyWallet.Shared.DTO;

namespace MyWallet.Repositories.Repositories
{
    public class TagRepository : ITagRepository
    {
        private readonly ApplicationContext _context;
        public TagRepository(ApplicationContext context)
        {
            _context = context;
        }

        public async Task<Tag> GetByIdAsync(Guid id, CancellationToken cancellationToken)
        {
            var obj = await _context.Set<Tag>().FindAsync(id);
            return obj;
        }

        public async Task UpdateAsync(Tag entity, CancellationToken cancellationToken)
        {
            entity.UpdateDate();
            _context.Entry(entity).State = EntityState.Modified;
        }

        public async Task DeleteAsync(Guid id)
        {
            var obj = await _context.Set<Tag>().FindAsync(id);

            if (obj is null)
                return;

            _context.Entry(obj).State = EntityState.Deleted;
        }

        public async Task<Tag> AddAsync(Tag tag, CancellationToken cancellationToken)
        {
            await _context.AddAsync(tag, cancellationToken);

            return tag;
        }

        public async Task<IEnumerable<Tag>> GetAllAsync(OwnerParametersDTO ownerParameters, CancellationToken cancellationToken)
        {
            var tags = await _context.Tags.OrderBy(on => on.Name)
                    .Skip((ownerParameters.PageNumber - 1) * ownerParameters.PageSize)
                    .Take(ownerParameters.PageSize).AsNoTracking().ToListAsync(cancellationToken);

            return tags;
        }
    }
}
