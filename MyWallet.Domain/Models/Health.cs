using MyWallet.Domain.Enums;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyWallet.Domain.Models
{
    [Table("HealthData")]
    public class Health : BaseEntity
    {
        public Health(Guid Id) : base(Id) { }

        public Health()
        {
                
        }
        public DateTime HealthDate { get; set; }

        [Column(TypeName = "decimal(10,3)")]
        public decimal Systolic {  get; set; }

        [Column(TypeName = "decimal(10,3)")]
        public decimal Diastolic { get; set; }

        [Column(TypeName = "decimal(10,3)")]
        public decimal Weight { get; set; }

        public ESleepQuality SleepQuality { get; set; }

        public bool IsTired { get; set; }

        [Column(TypeName = "decimal(10,3)")]
        public decimal StomachSize { get; set; }
    }
}
