using MyWallet.Services.Responses;
using MyWallet.Shared.DTO;

namespace MyWallet.Services.Contracts
{
    public interface IInvoiceService
    {
        Task<ResponseBase> GetInvoicesAsync(IntervalDTO filters, CancellationToken cancellationToken);
    }
}
