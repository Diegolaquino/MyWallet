using System.ComponentModel.DataAnnotations.Schema;

namespace MyWallet.Domain.Models
{
    [Table("Goals")]
    public class Goal : BaseEntity
    {
        public Goal() : base()
        {
                
        }

        public Goal(Guid id) : base(id)
        {
            
        }

        public string Name { get; set; }

        public decimal Limit { get; set; }

        public Guid CategoryId { get; set; }

        public Category Category { get; set; }

        [NotMapped]
        public string CategoryName { get; set; }
    }
}
