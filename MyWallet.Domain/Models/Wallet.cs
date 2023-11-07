using MyWallet.Domain.Enums;
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

        public IList<Expense>? Expenses { get; set; }

       // public EWalletType? WalletType { get; set; }
    }
}
