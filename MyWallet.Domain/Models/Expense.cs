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

        [Column(TypeName = "decimal(18,4)")]
        public decimal Value { get; set; }

        [ForeignKey("WalletId")]
        public Guid? WalletId { get; set; }

        public Wallet? Wallet { get; set; }

        [ForeignKey("CategoryId")]
        public Guid CategoryId { get; set; }

        public virtual Category Category { get; set; }  

        public virtual List<Tag> Tags { get; set; }

        public int? Installments { get; set; } = 1;

        public bool Paid { get; set; }

        [Column(TypeName = "VARCHAR")]
        [StringLength(200)]
        public string Comments { get; set; }
    }
}
