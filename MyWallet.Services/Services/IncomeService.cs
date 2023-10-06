using MyWallet.Services.Contracts;
using MyWallet.Services.Responses;
using MyWallet.Shared.DTO;

namespace MyWallet.Services.Services
{
    public class IncomeService : IIncomeService
    {
        public Task DeleteAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<ResponseBase> GetAll(OwnerParametersDTO ownerParameters, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<ResponseBase> GetEntity(Guid id, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<ResponseBase> Save(IncomeEntryDTO dto, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(IncomeEntryDTO entity, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
