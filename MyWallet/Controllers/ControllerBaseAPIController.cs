//using Microsoft.AspNetCore.Http;
//using Microsoft.AspNetCore.Mvc;
//using MyWallet.Services.Contracts;
//using MyWallet.Shared.DTO;
//using System.Net;

//namespace MyWallet.API.Controllers
//{
//    [Route("api/[controller]")]
//    [ApiController]
//    public abstract class ControllerBaseAPIController : ControllerBase
//    {
//        [ProducesResponseType((int)HttpStatusCode.NoContent)]
//        [ProducesResponseType(typeof(IEnumerable<IncomeDTO>), (int)HttpStatusCode.NoContent)]
//        [HttpGet]
//        public async Task<IActionResult> GetAll([FromQuery] OwnerParametersDTO filters, CancellationToken cancellationToken)
//        {
//            var response = await _incomeService.GetAll(filters, cancellationToken);

//            return StatusCode(response.StatusCode, response);
//        }
//    }
//}
