using Microsoft.EntityFrameworkCore;
using MyWallet.Domain.Models;

namespace MyWallet.Data
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options)
            : base(options)
        { }

        public DbSet<Category> Categories { get; set; }
    }
}