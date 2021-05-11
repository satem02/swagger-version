using Application.ProductServiceLocator.Commands.CreateProductServiceLocator;
using Application.ProductServiceLocator.Commands.DeleteProductServiceLocator;
using Application.ProductServiceLocator.Commands.UpdateProductServiceLocator;
using Application.ProductServiceLocator.Queries.GetProductServiceLocator;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using WebAPI.Controllers;

namespace WebAPI.V1.Controller
{    
    [ApiVersion("1.0")]  
    [Route("api/v{version:apiVersion}/[controller]")] 
    [ApiController] 
    public class ProductServiceLocatorController : ApiControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<ProductServiceLocatorItemVm>> Get()
        {
            return await Mediator.Send(new GetProductServiceLocatorItemsQuery());
        }

        [HttpPost]
        public async Task<ActionResult<Guid>> Create(CreateProductServiceLocatorCommand command)
        {
            return await Mediator.Send(command);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Update(Guid id, UpdateProductServiceLocatorCommand command)
        {
            if (id != command.Id)
            {
                return BadRequest();
            }

            await Mediator.Send(command);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(Guid id)
        {
            await Mediator.Send(new DeleteProductServiceLocatorCommand { Id = id });

            return NoContent();
        }
    }
}
