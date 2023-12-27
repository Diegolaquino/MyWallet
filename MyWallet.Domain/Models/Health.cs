using MyWallet.Domain.Enums;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyWallet.Domain.Models
{
    [Table("HealthData")]
    public class Health : BaseEntity
    {
        public int Systolic {  get; set; }

        public int Diastolic { get; set; }

        [Column(TypeName = "decimal(10,3)")]
        public decimal Weight { get; set; }

        public ESleepQuality SleepQuality { get; set; }

        public bool IsTired { get; set; }

        public int StomachSize { get; set; }
    }
}
