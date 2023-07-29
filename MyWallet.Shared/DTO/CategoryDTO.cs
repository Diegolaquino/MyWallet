using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyWallet.Shared.DTO
{
    public record CategoryEntryDTO(Guid UserId, string Name);

    public record CategoryDTO(Guid id, string name, Guid userId);
}
