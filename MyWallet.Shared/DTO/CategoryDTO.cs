using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyWallet.Shared.DTO
{
    public class CategoryEntryDTO
    {
        public Guid UserId { get; set; } = Guid.Parse("2b23f7fa-58f4-4c9e-98ab-f79e3818b529");
        public string Name { get; set; }
    }

    public class CategoryDTO
    {
        public Guid Id { get; set; }
        public string Name { get; set; }

        public Guid UserId { get; set; }
    }
}
