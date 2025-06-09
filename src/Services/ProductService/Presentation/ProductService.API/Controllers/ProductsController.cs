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

            if (products == null || !products.Any())
            {
                return Ok(new List<Product>());
            }

            return Ok(products);
        }

        [HttpPost]
        public async Task<IActionResult> CreateProduct([FromBody] CreateProductCommand command, CancellationToken cancellationToken)
        {
            if (command == null)
            {
                return BadRequest("Invalid product data.");
            }

            var newProductId = await _mediator.Send(command, cancellationToken);
            return CreatedAtAction(nameof(GetAllProducts), new { id = newProductId }, new { Id = newProductId });
        }
    }
}
