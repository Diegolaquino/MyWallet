using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyWallet.Shared.DTO
{
    public class IncomeDTO : IncomeEntryDTO
    {
        public Guid Id { get; set; }
    }
    public class IncomeEntryDTO
    {
        public Decimal Value { get; set; }

        public DateTime CreatedDate { get; set; }

        public CategoryDTO Category { get; set; }

        public List<string>? Tags { get; set; }

        public string? Comments { get; set; }

        public WalletDTO? Wallet { get; set; }

        public int? Installments { get; set; }
    }
}
