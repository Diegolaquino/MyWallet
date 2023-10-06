using MyWallet.Services.Responses;
using MyWallet.Shared.DTO;

namespace MyWallet.Services.Contracts
{
    public interface IExpenseService : IBaseService<ExpenseEntryDTO>
    {
        Task<ResponseBase> GetExpensesByInterval(ExpenseIntervalDTO expenseInterval, CancellationToken cancellationToken);
    }
}
