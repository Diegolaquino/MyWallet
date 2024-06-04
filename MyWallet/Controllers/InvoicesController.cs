using Microsoft.AspNetCore.Mvc;
using MyWallet.Services.Services;
using MyWallet.Shared.DTO;

namespace MyWallet.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InvoicesController : ControllerBase
    {
        private readonly InvoiceService _invoiceService;
        public InvoicesController(InvoiceService invoiceService)
        {
            _invoiceService = invoiceService;
        }

        // GET api/<ExpensesController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(IntervalDTO filters, CancellationToken cancellationToken)
        {
            var response = await _invoiceService.GetInvoicesAsync(filters, cancellationToken);

            return StatusCode(response.StatusCode, response);
        }
    }
}
