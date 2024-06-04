using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace MyWallet.Domain.Models
{
    [Table("Invoices")]
    public class Invoice : BaseEntity
    {
        public Invoice() : base() { }

        public Invoice(Guid Id) : base(Id) { }

        public Wallet Wallet { get; set; }

        [ForeignKey("WalletId")]
        public Guid WalletId {  get; set; } 

        [Column(TypeName = "decimal(18,3)")]
        public decimal Value { get; set; }

        [Column(TypeName = "VARCHAR")]
        [StringLength(200)]
        public string Comments { get; set; }

        public DateTime DuoDate { get; set; }

        public int QuantityEntries { get; set; }
    }
}
