namespace MyWallet.Shared.DTO
{
    public class WalletDTO
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public List<ExpenseDTO> Expenses { get; set; }
    }
}
