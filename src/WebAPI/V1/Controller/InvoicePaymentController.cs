using Application.V1.CreditPayment.Denizbank.Queries.InvoiceQuery;
using Application.V1.CreditPayment.Fibabank.Queries.InvoiceQuery;
using Application.Common.Interfaces;
using WebAPI.Controllers;
using Domain.Entities;
using Domain.Enums;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebAPI.V1.Models.Request;
using WebAPI.V1.Models.Response;
using Application.ProductServiceLocator.Queries.GetProductServiceLocator;
using System.Linq;

namespace WebAPI.V1.Controller
{    
    [ApiVersion("1.0")]  
    [Route("api/v{version:apiVersion}/[controller]")] 
    [ApiController] 
    public class InvoicePaymentController : ApiControllerBase
    {
        private readonly ICurrentUserService currentUserService;

        public InvoicePaymentController(ICurrentUserService currentUserService)
        {
            this.currentUserService = currentUserService;
        }

        [HttpPost]
        public async Task<QueryInvoicesResponse> QueryInvoices(QueryInvoicesRequest request)
        {
            var serviceLocatorResponse = await Mediator.Send(new GetProductServiceLocatorItemsQuery());
            var response = new QueryInvoicesResponse();
            
            var serviceLocator = serviceLocatorResponse.Lists.FirstOrDefault(x=>x.ProcessType == ProcessType.InvoicePayment && x.TenantId  == currentUserService.TenantId);

            if(serviceLocator.InstitutionType == InstitutionType.Denizbank)
            {
                var serviceRequest = new DenizbankInvoiceQuery();
                var serviceResponse = await Mediator.Send(serviceRequest);

                // Map to response
            }

            else if(serviceLocator.InstitutionType == InstitutionType.Fibabank)
            {
                var serviceRequest = new FibabankInvoiceQuery() {
                    AccountNo = request.AccountNo,
                    Tckn = request.Tckn
                };
                
                var serviceResponse = await Mediator.Send(serviceRequest);

                // Map to response
            }

            return response;
        }
    }
}