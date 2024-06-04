using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyWallet.Shared.DTO
{
    public class BalanceDTO
    {
        public decimal Income { get; set; }

        public decimal Others { get; set; }

        public decimal Expense { get; set; }

        public decimal Total { get; set; }
    }
}
