namespace MyWallet.Shared.DTO
{
    public class WalletDTO
    {
        public int? WalletType { get; set; }
        public Guid? Id { get; set; }
        public string Name { get; set; }
        public List<ExpenseDTO>? Expenses { get; set; }

        public List<IncomeDTO>? Incomes { get; set; }
    }
}
