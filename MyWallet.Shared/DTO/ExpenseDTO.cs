﻿using System.Text.Json.Serialization;

namespace MyWallet.Shared.DTO
{
    public abstract class ExpenseBaseDto
    {
        public DateTime ExpenseDate { get; set; }

        public Decimal Value { get; set; }

        public Guid CategoryId { get; set; }

        [JsonPropertyName("tags")]
        public string Tags { get; set; }

        public string? Comments { get; set; }

        public Guid? WalletId { get; set; }

        public int? InstallmentsQuantity { get; set; }

        public int Installment { get; set; } = 0;
    }

    public class ExpenseDTO : ExpenseBaseDto
    {
        [JsonPropertyName("expenseId")]
        public Guid Id { get; set; }

        public string WalletName { get; set; }

        public string CategoryName { get; set; }
    }

    public class ExpenseEntryDTO : ExpenseBaseDto
    {
        public CategoryDTO? Category { get; set; }
        public WalletDTO? Wallet { get; set; }

        public ExpenseEntryDTO ShallowCopy()
        {
            return (ExpenseEntryDTO)this.MemberwiseClone();
        }

        public ExpenseEntryDTO DeepCopy(int installments)
        {
            ExpenseEntryDTO other = (ExpenseEntryDTO)this.MemberwiseClone();
            other.ExpenseDate = ExpenseDate.AddMonths(installments);
            return other;
        }

        public void AddMonth(int number)
        {
            this.ExpenseDate = ExpenseDate.AddMonths(number);
        }

        public void AddInstallment(int i)
        {
            this.Installment = i;
        }
    }
}
