using Microsoft.Data.SqlClient;
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

        public DbSet<FixedEntry> FixedEntries { get; set; }

        public DbSet<WalletMonth> WalletsMonth { get; set; }

        public DbSet<Wallet> Wallets { get; set; }

        public DbSet<Reminder> Reminders { get; set; }

        public DbSet<Health> Healths { get; set; }

        public DbSet<Exercise> Exercises { get; set; }

        public DbSet<Invoice> Invoices { get; set; }

        public DbSet<Goal> Goals { get; set; }

        //public DbSet<Balance> Balances { get; set; }

        public DbSet<ExpenseAndCategory> ExpenseAndCategories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ExpenseAndCategory>().ToView("V_EXPENSES_WITH_CATEGORY");

            modelBuilder.Entity<Expense>()
            .Property(b => b.Value)
               .HasColumnType("decimal(18,2)");

            modelBuilder.Entity<Health>()
            .Property(b => b.Weight)
               .HasColumnType("decimal(10,3)");

            modelBuilder.Entity<Balance>().HasNoKey();

            modelBuilder.Entity<WalletMonth>().HasNoKey();
        }

        public async Task<Balance> CalculateBalanceAsync(int month, int year, CancellationToken cancellationToken)
        {
            var parameters = new[]
            {
            new SqlParameter("@p_month", month),
            new SqlParameter("@p_year", year)
        };

            var results = await this.Set<Balance>()
                .FromSqlRaw("EXECUTE dbo.CalculateBalance @p_month, @p_year", parameters)
                .AsNoTracking()
                .ToListAsync(cancellationToken);

            return results.FirstOrDefault();
        }

        public async Task<IEnumerable<WalletMonth>> GetMonthlyExpensesWithTypeAsync(int month, int year, int type, CancellationToken cancellationToken)
        {
            var parameters = new[]
            {
                new SqlParameter("@p_month", month),
                new SqlParameter("@p_year", year),
                new SqlParameter("@p_type", type)
            };

            var results = await this.Set<WalletMonth>()
                .FromSqlRaw("EXECUTE dbo.GetMonthlyExpensesWithType @p_month, @p_year, @p_type", parameters)
                .AsNoTracking()
                .ToListAsync(cancellationToken);

            return results;
        }
    }
}