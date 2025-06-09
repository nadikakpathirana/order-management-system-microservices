using MediatR;
using Microsoft.AspNetCore.Mvc;
using ProductService.Application.Features.Products.Commands;
using ProductService.Application.Features.Products.Queries;
using ProductService.Domain.Entities;

namespace ProductService.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ProductsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllProducts(CancellationToken cancellationToken)
        {
            var query = new GetAllProductQuery();
            var products = await _mediator.Send(query, cancellationToken);

            return Ok(products);
        }

        [HttpGet("GetProduct/{id:int}")]
        public async Task<IActionResult> GetProduct(int id, CancellationToken cancellationToken)
        {
            var query = new GetProductQuery{ Id = id };
            var product = await _mediator.Send(query, cancellationToken);

            if (product == null)
            {
                return NotFound($"Product with ID {id} not found.");
            }

            return Ok(product);
        }

        [HttpPost("CreateProduct")]
        public async Task<IActionResult> CreateProduct([FromBody] CreateProductCommand createCommand, CancellationToken cancellationToken)
        {
            var newProductId = await _mediator.Send(createCommand, cancellationToken);
            return CreatedAtAction(nameof(CreateProduct), new { id = newProductId }, new { Id = newProductId });
        }

        [HttpPost("UpdateProduct")]
        public async Task<IActionResult> UpdateProduct([FromBody] UpdateProductCommand updateCommand, CancellationToken cancellationToken)
        {
            var result = await _mediator.Send(updateCommand, cancellationToken);
            return Ok(result);
        }

        [HttpPost("DeleteProduct/{id:int}")]
        public async Task<IActionResult> DeleteProduct(int id, CancellationToken cancellationToken)
        {
            var result = await _mediator.Send(new DeleteProductCommand{Id = id}, cancellationToken);
            return Ok(result);
        }
    }
}
