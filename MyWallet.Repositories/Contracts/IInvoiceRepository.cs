using MyWallet.Domain.Models;
using MyWallet.Services.Responses;

namespace MyWallet.Repositories.Contracts
{
    public interface IInvoiceRepository : IRepositoryBase<Invoice>
    {
        Task<IEnumerable<Invoice>> GetByDateInterval(DateTime start, DateTime end, CancellationToken cancellationToken);
    }
}
