namespace MyWallet.Domain.Models
{
    public class Entry : BaseEntity
    {
        public Entry(Guid id) : base(id)
        {

        }

        public Category Category { get; set; }
        public decimal Value { get; set; }

        public string Name { get; set; }

        public int Installments { get; set; } = 1;
    }
}