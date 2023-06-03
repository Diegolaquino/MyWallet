using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyWallet.Shared.DTO
{
    public class CategoryEntryDTO
    {
        public Guid UserId { get; set; }
        public string Name { get; set; }
    }

    public class CategoryDTO
    {
        public Guid Id { get; set; }
        public string Name { get; set; }

        public Guid UserId { get; set; }
    }
}
