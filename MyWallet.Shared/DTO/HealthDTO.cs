using MyWallet.Domain.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyWallet.Shared.DTO
{
    public class HealthDTO
    {
        public int Systolic { get; set; }

        public int Diastolic { get; set; }

        public decimal Weight { get; set; }

        public int SleepQuality { get; set; }

        public bool IsTired { get; set; }

        public int StomachSize { get; set; }
    }
}
