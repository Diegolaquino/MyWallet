using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace MyWallet.Domain.Models
{
    public class Reminder : BaseEntity
    {
        public Reminder()
        {
                
        }

        public bool Resolved { get; set; }

        [Column(TypeName = "VARCHAR")]
        [StringLength(100)]
        public string Name { get; set; }

        [Column(TypeName = "VARCHAR")]
        [StringLength(200)]
        public string Comments { get; set; }
    }
}
