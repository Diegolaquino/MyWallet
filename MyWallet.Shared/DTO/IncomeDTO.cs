using System.Text.Json.Serialization;

namespace MyWallet.Shared.DTO
{
    public class IncomeDTO : IncomeEntryDTO
    {
        [JsonPropertyName("incomeId")]
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

        public Guid? WalletId { get; set; }

        public int? InstallmentsQuantity { get; set; }

        public int Installment { get; set; } = 0;

        public IncomeEntryDTO ShallowCopy()
        {
            return (IncomeEntryDTO)this.MemberwiseClone();
        }

        public IncomeEntryDTO DeepCopy(int installments)
        {
            IncomeEntryDTO other = (IncomeEntryDTO)this.MemberwiseClone();
            other.IncomeDate = IncomeDate.AddMonths(installments);
            return other;
        }

        public void AddMonth(int number)
        {
            this.IncomeDate = IncomeDate.AddMonths(number);
        }

        public void AddInstallment(int i)
        {
            this.Installment = i;
        }
    }
}
