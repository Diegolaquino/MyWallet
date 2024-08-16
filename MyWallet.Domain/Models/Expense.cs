using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyWallet.Domain.Models
{
    [Table("Expenses")]
    public class Expense : BaseEntity
    {
        public Expense(Guid Id) : base(Id) 
        {
            
        }

        public Expense()
        {
        }

        public DateTime ExpenseDate { get; set; }

        [Column(TypeName = "decimal(18,3)")]
        public decimal Value { get; set; }

        [Column(TypeName = "decimal(18,3)")]
        public decimal? TotalValue { get; set; }

        [ForeignKey("WalletId")]
        public Guid? WalletId { get; set; }

        public Wallet? Wallet { get; set; }

        [NotMapped]
        public string WalletName { get; set; }

        [NotMapped]
        public int? ShoppingDay { get; set; }

        [NotMapped]
        public int WalletType { get; set; }

        [ForeignKey("CategoryId")]
        public Guid CategoryId { get; set; }

        public Category Category { get; set; }

        [NotMapped]
        public string CategoryName { get; set; }

        [Column(TypeName = "VARCHAR")]
        [StringLength(200)]
        public string Tags { get; set; }

        public int? InstallmentsQuantity { get; set; } = 1;

        public bool Paid { get; set; }

        [Column(TypeName = "VARCHAR")]
        [StringLength(200)]
        public string Comments { get; set; }

        [Column(TypeName = "VARCHAR")]
        [StringLength(80)]
        public string Name { get; set; }

        public int Installment { get; set; } = 1;

        public bool IsFixed { get; set; } = false;

        public EType Type { get; set; } = EType.Expense;

        public Guid? TrackingId { get; set; }
        
    }

    public enum EType
    {
        Expense = 1,
        Income = 2,
        Others = 3
    }

    public class ExpenseAndCategory
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public Guid CategoryId { get; set; }
        public decimal Value { get; set; }
        public DateTime ExpenseDate { get; set; }
        public EType Type { get; set; }
    }
}
