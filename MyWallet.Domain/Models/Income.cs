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

        public DateTime IncomeDate { get; set; }

        [ForeignKey("CategoryId")]
        public Guid CategoryId { get; set; }

        public Category Category { get; set; }

        [Column(TypeName = "decimal(18,4)")]
        public decimal Value { get; set; }
        public int Installments { get; set; } = 1;

        [Column(TypeName = "VARCHAR")]
        [StringLength(200)]
        public string Tags { get; set; }

        [Column(TypeName = "VARCHAR")]
        [StringLength(200)]
        public string Comments { get; set; }
    }
}