using MyWallet.Services.Responses;
using MyWallet.Shared.DTO;

namespace MyWallet.Services.Contracts
{
    public interface IHealthService : IBaseService<HealthDTO>
    {
        Task<ResponseBase> GetHealthByIntervalAsync(IntervalDTO intervalDTO, CancellationToken cancellationToken);
    }
}
