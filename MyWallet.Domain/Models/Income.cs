namespace MyWallet.Domain.Models
{
    public class Income : BaseEntity
    {
        public Income(Guid id) : base(id)
        {

        }

        public Category Category { get; set; }
        public decimal Value { get; set; }

        public string Name { get; set; }

        public int Installments { get; set; } = 1;

        public virtual List<Tag> Tags { get; set; }
    }
}