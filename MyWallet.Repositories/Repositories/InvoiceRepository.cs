using MyWallet.Data;
using MyWallet.Domain.Models;
using MyWallet.Repositories.Contracts;
using MyWallet.Services.Responses;
using MyWallet.Shared.DTO;

namespace MyWallet.Repositories.Repositories
{
    public class InvoiceRepository : IInvoiceRepository
    {
        private readonly ApplicationContext _context;

        public InvoiceRepository(ApplicationContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Invoice>> GetByDateInterval(DateTime start, DateTime end, CancellationToken cancellationToken)
        {
            var invoices = _context.Invoices.Where(e => e.DuoDate.Date >= start.Date && e.DuoDate.Date <= end.Date).ToList();

            return invoices;
        }


        public async Task<Invoice> AddAsync(Invoice entity, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public async Task DeleteAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Invoice>> GetAllAsync(OwnerParametersDTO ownerParameters, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public async Task<Invoice> GetByIdAsync(Guid id, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public async Task UpdateAsync(Invoice entity, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
