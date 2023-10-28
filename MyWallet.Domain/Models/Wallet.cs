using System.ComponentModel.DataAnnotations.Schema;

namespace MyWallet.Domain.Models
{
    [Table("Wallets")]
    public class Wallet : BaseEntity
    {
        public Wallet()
        {
                
        }

        public string Name { get; set; }

        public virtual IList<Expense>? Expenses { get; set; }
    }
}
