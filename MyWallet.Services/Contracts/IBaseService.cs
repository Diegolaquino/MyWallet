using MyWallet.Services.Responses;
using MyWallet.Shared.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyWallet.Services.Contracts
{
    public interface IBaseService<TEntityDTO>
    {
        Task<ResponseBase> GetAll(OwnerParametersDTO ownerParameters, CancellationToken cancellationToken);

        Task<ResponseBase> GetEntityAsync(Guid id, CancellationToken cancellationToken);

        Task<ResponseBase> SaveAsync(TEntityDTO dto, CancellationToken cancellationToken);

        Task UpdateAsync(TEntityDTO entity, CancellationToken cancellationToken);

        Task DeleteAsync(Guid id);
    }
}
