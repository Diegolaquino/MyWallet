using MyWallet.Services.Responses;
using MyWallet.Shared.DTO;

namespace MyWallet.Services.Contracts
{
    public interface IExpenseService : IBaseService<ExpenseEntryDTO>
    {
        Task<ResponseBase> GetExpensesByInterval(IntervalDTO expenseInterval, CancellationToken cancellationToken);

        Task<ResponseBase> GetFixedEntriesAsync(CancellationToken cancellationToken);

        Task<ResponseBase> GetBalanceAsync(int month, int year, CancellationToken cancellationToken);
        Task<ResponseBase> GetExpenseWithInstallmentsAsync(int month, int year, CancellationToken cancellationToken);
        Task<ResponseBase> GetLastExpenseAsync(CancellationToken cancellationToken);
    }
}
