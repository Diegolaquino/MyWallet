using AutoMapper;
using MyWallet.Repositories.Contracts;
using MyWallet.Repositories.Repositories;
using MyWallet.Services.Contracts;
using MyWallet.Services.Responses;
using MyWallet.Shared.DTO;
using System.Net;

namespace MyWallet.Services.Services
{
    public class InvoiceService : IInvoiceService
    {
        private readonly IInvoiceRepository _invoiceRepository;
        private readonly IMapper _mapper;

        public InvoiceService(IInvoiceRepository invoiceRepository)
        {
            _invoiceRepository = invoiceRepository;
        }

        public async Task<ResponseBase> GetInvoicesAsync(IntervalDTO filters, CancellationToken cancellationToken)
        {
            var invoices = await _invoiceRepository.GetByDateInterval(filters.Start, filters.End, cancellationToken);

            if (invoices is null)
                return new FailureResponse((int)HttpStatusCode.NoContent, $"{nameof(invoices)} null or empty");

            return new SucessResponse<IEnumerable<InvoiceDTO>>((int)HttpStatusCode.OK, _mapper.Map<IEnumerable<InvoiceDTO>>(invoices));
        }
    }
}
