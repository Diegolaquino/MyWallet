namespace MyWallet.Domain.Models
{
    public class Expense : BaseEntity
    {
        public Expense(Guid Id) : base(Id) 
        {
            
        }

        public Expense()
        {
            
        }

        public decimal Value { get; set; }

        public Category Category { get; set; }  

        public virtual List<Tag> Tags { get; set; }
       
    }

    public class Tag
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
    }
}
