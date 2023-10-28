using System.ComponentModel.DataAnnotations.Schema;

namespace MyWallet.Domain.Models
{
    [Table("Tags")]
    public class Tag : BaseEntity
    {
        public string Name { get; set; }
    }
}
