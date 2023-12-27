using MyWallet.Services.Contracts;
using MyWallet.Services.Responses;
using MyWallet.Shared.DTO;

namespace MyWallet.Services.Services
{
    public class HealthService : IHealthService
    {
        public async Task DeleteAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<ResponseBase> GetAll(OwnerParametersDTO ownerParameters, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public async Task<ResponseBase> GetEntityAsync(Guid id, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public async Task<ResponseBase> SaveAsync(HealthDTO dto, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public async Task UpdateAsync(HealthDTO entity, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
