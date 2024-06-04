using Microsoft.AspNetCore.Mvc;
using MyWallet.Services.Contracts;
using MyWallet.Services.Responses;
using MyWallet.Shared.DTO;
using System.Net;

namespace MyWallet.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WalletsController : ControllerBase
    {
        private readonly IWalletService _walletService;
        public WalletsController(IWalletService walletService)
        {
            _walletService = walletService;
        }

        // GET: api/<WalletsController>
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        [ProducesResponseType(typeof(IEnumerable<WalletDTO>), (int)HttpStatusCode.NoContent)]
        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] OwnerParametersDTO filters, CancellationToken cancellationToken)
        {
            var response = await _walletService.GetAll(filters, cancellationToken);

            return StatusCode(response.StatusCode, response);
        }

        // GET api/<WalletsController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id, CancellationToken cancellationToken)
        {
            var response = await _walletService.GetEntityAsync(id, cancellationToken);

            return StatusCode(response.StatusCode, response);
        }

        // POST api/<WalletsController>
        [ProducesResponseType(typeof(SucessResponse<WalletDTO>), (int)HttpStatusCode.Created)]
        [ProducesResponseType(typeof(FailureResponse), (int)HttpStatusCode.BadRequest)]
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] WalletDTO requestWallet, CancellationToken cancellationToken)
        {
            var wallet = await _walletService.SaveAsync(requestWallet, cancellationToken);

            return StatusCode(wallet.StatusCode, wallet);
        }

        // PUT api/<WalletsController>/5
        [HttpPut]
        public async Task<IActionResult> Put([FromBody] WalletDTO value, CancellationToken cancellationToken)
        {
            await _walletService.UpdateAsync(value, cancellationToken);

            return Ok();
        }

        // DELETE api/<WalletsController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            await _walletService.DeleteAsync(id);

            return NoContent();
        }
    }
}
