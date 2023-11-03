using MyWallet.Services.Responses;
using MyWallet.Shared.DTO;

namespace MyWallet.Services.Contracts
{
    public interface IIncomeService : IBaseService<IncomeEntryDTO>
    {
        Task<ResponseBase> GetIncomesByInterval(IncomeIntervalDTO incomeInterval, CancellationToken cancellationToken);
    }
}
