namespace MyWallet.Domain.Models
{
    public class Balance
    {
        public decimal? Income { get; set; }

        public decimal? Others { get; set; }

        public decimal? Expense { get; set; }

        public decimal? FixedEntries { get; set; }

        public decimal? Total { get; set; }
    }
}
