namespace MyWallet.Shared.DTO
{
    public class IncomeDTO : IncomeEntryDTO
    {
        public Guid Id { get; set; }
    }

    public class IncomeEntryDTO
    {
        public DateTime IncomeDate { get; set; }
        public Decimal Value { get; set; }

        public CategoryDTO? Category { get; set; }

        public Guid CategoryId { get; set; }

        public string Tags { get; set; }

        public string? Comments { get; set; }

        public WalletDTO? Wallet { get; set; }

        public int? Installments { get; set; }
    }
}
