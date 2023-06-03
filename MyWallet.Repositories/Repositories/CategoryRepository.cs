using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MyWallet.Data;
using MyWallet.Domain.Models;
using MyWallet.Repositories.Contracts;
using MyWallet.Shared.DTO;

namespace MyWallet.Repositories.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly ApplicationContext _context;
        public CategoryRepository(ApplicationContext context)
        {
            _context = context;
        }

        public async Task<Category> GetByIdAsync(Guid id)
        {
            var obj = await _context.Set<Category>().FindAsync(id);
            return obj;
        }

        public async Task UpdateAsync(Category entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
        }

        public async Task DeleteAsync(Guid id)
        {
            var obj = await _context.Set<Category>().FindAsync(id);

            if (obj is null)
                return;

            _context.Entry(obj).State = EntityState.Deleted;
        }

        public async Task<Category> AddAsync(Category category)
        {
            await _context.AddAsync(category);

            return category;
        }

        public async Task<IEnumerable<Category>> GetAllAsync(OwnerParametersDTO ownerParameters)
        {
            var categories = await _context.Categories.OrderBy(on => on.Name)
                    .Skip((ownerParameters.PageNumber - 1) * ownerParameters.PageSize)
                    .Take(ownerParameters.PageSize).AsNoTracking().ToListAsync();

            return categories;
        }
    }
}
