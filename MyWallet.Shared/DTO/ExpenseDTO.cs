namespace MyWallet.Shared.DTO
{
    public class ExpenseDTO : ExpenseEntryDTO
    {
        public Guid Id { get; set; }
    }

    public class ExpenseEntryDTO
    {
        public Decimal Value { get; set; }

        public DateTime CreatedDate { get; set; }

        public CategoryDTO Category { get; set; }  
        
        public List<string>? Tags { get; set; }

        public string? Comments { get; set; }

        public WalletDTO? Wallet { get; set; }
    } 
}
