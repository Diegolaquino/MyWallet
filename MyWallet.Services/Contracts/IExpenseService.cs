using MyWallet.Services.Responses;
using MyWallet.Shared.DTO;

namespace MyWallet.Services.Contracts
{
    public interface IExpenseService : IBaseService<ExpenseEntryDTO>
    {
        Task<ResponseBase> GetExpensesByInterval(IntervalDTO expenseInterval, CancellationToken cancellationToken);
    }
}
