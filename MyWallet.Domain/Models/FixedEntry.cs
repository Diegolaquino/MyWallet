using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyWallet.Domain.Models
{
    [Table("FixedEntries")]
    public class FixedEntry : BaseEntity
    {
        public FixedEntry()
        {
                
        }

        public FixedEntry(Guid guid) : base(guid) { }

        [Column(TypeName = "decimal(18,4)")]
        public decimal Value { get; set; }

        [Column(TypeName = "VARCHAR")]
        [StringLength(80)]
        public string Name { get; set; }

        public Category Category { get; set; }

        [ForeignKey("CategoryId")]
        public Guid CategoryId { get; set; }

        public Wallet Wallet { get; set; }

        [ForeignKey("WalletId")]
        public Guid WalletId { get; set; }

        [Column(TypeName = "VARCHAR")]
        [StringLength(200)]
        public string Comments { get; set; }

    }
}
