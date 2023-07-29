using System.ComponentModel.DataAnnotations.Schema;

namespace MyWallet.Domain.Models
{
    [Table("Categories")]
    public class Category : BaseEntity
    {
        public Category() : base() { }

        public Category(Guid id) : base(id)
        {

        }

        public string Name { get; set; }
    }
}
