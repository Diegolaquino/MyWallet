using Microsoft.EntityFrameworkCore;
using MyWallet.Data;
using MyWallet.Domain.Models;
using MyWallet.Repositories.Contracts;
using MyWallet.Shared.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyWallet.Repositories.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly ApplicationContext _context;
        public CategoryRepository(ApplicationContext context)
        {
            _context = context;
        }

        public async Task<CategoryDTO> GetById(Guid id)
        {
            var obj = await _context.Set<CategoryDTO>().FindAsync(id);
            return obj;
        }

        public void Update(CategoryDTO entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
        }

        public async Task Delete(Guid id)
        {
            var obj = await _context.Set<CategoryDTO>().FindAsync(id);

            if (obj is null)
                return;

            _context.Entry(obj).State = Microsoft.EntityFrameworkCore.EntityState.Deleted;
        }

        public async Task Save(CategoryDTO category)
        {
            await _context.AddAsync(category);
        }

        public async Task<IEnumerable<Category>> GetAll()
        {
            var categories = await _context.Categories.AsNoTracking().ToListAsync();

            return categories;
        }
    }
}
