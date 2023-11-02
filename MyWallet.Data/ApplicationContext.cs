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

        public DbSet<Expense> Expenses { get; set; }

        public DbSet<Wallet> Wallets { get; set; }

        public DbSet<Income> Incomes { get; set; }

        public DbSet<Tag> Tags { get; set; }

        public DbSet<Reminder> Reminders { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Expense>()
            .Property(b => b.Value)
               .HasColumnType("decimal(18,2)");

            modelBuilder.Entity<Income>()
            .Property(b => b.Value)
               .HasColumnType("decimal(18,2)");
        }
    }
}