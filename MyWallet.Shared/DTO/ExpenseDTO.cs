namespace MyWallet.Shared.DTO
{
    public class ExpenseDTO : ExpenseEntryDTO
    {
        public Guid Id { get; set; }
    }

    public class ExpenseEntryDTO
    {
        public DateTime ExpenseDate { get; set; }

        public Decimal Value { get; set; }

        public CategoryDTO? Category { get; set; }

        public Guid CategoryId { get; set; }

        public List<TagDTO>? Tags { get; set; }

        public string? Comments { get; set; }

        public WalletDTO? Wallet { get; set; }

        public int? Installments { get; set; }
    } 
}
