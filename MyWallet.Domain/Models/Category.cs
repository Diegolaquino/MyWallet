namespace MyWallet.Domain.Models
{
    public class Category : BaseEntity
    {
        public Category(Guid id) : base(id)
        {

        }

        public string Name { get; set; }
    }
}
