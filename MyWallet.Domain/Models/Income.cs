using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyWallet.Domain.Models
{
    [Table("Incomes")]
    public class Income : BaseEntity
    {
        public Income()
        {
                
        }
        public Income(Guid id) : base(id)
        {

        }

        [ForeignKey("CategoryId")]
        public Guid CategoryId { get; set; }

        public Category Category { get; set; }

        [Column(TypeName = "decimal(18,4)")]
        public decimal Value { get; set; }

        public string Name { get; set; }

        public int Installments { get; set; } = 1;

        public virtual List<Tag> Tags { get; set; }

        [Column(TypeName = "VARCHAR")]
        [StringLength(200)]
        public string Comments { get; set; }
    }
}