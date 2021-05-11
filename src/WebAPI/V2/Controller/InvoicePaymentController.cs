using WebAPI.Controllers;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Application.V1.CreditPayment.Fibabank.Queries.InvoiceQuery;

namespace WebAPI.V2.Controller
{
    [ApiVersion("2.0")]  
    [Route("api/v{version:apiVersion}/[controller]")] 
    [ApiController] 
    public class InvoicePaymentController : ApiControllerBase
    {
        [HttpGet]
        public async Task<FibabankInvoiceVm> Get()
        {
            return await Mediator.Send(new FibabankInvoiceQuery());
        }
    }
}