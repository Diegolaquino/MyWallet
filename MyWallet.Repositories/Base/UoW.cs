using MyWallet.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyWallet.Repositories.Base
{
    public class UoW : IUoW
    {
        private readonly ApplicationContext _context;
        public UoW(ApplicationContext context)
        {
            _context = context;
        }
        public async Task CommitAsync()
        {
            await _context.SaveChangesAsync();
        }
    }

    public interface IUoW
    {
        Task CommitAsync();
    }
}
