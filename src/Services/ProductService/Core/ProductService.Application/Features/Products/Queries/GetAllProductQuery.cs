using MediatR;
using ProductService.Domain.Entities;

namespace ProductService.Application.Features.Products.Queries;

public class GetAllProductQuery : IRequest<IEnumerable<Product>>
{
    internal sealed class GetAllProductQueryHandler : IRequestHandler<GetAllProductQuery, IEnumerable<Product>>
    {
        public async Task<IEnumerable<Product>> Handle(GetAllProductQuery request, CancellationToken cancellationToken)
        {
            // Logic to retrieve all products
            var products = new List<Product>
            {
                new Product { Name = "Product1", Description = "Description1", Rate = 10.0m },
                new Product { Name = "Product2", Description = "Description2", Rate = 20.0m }
            };

            return await Task.FromResult(products);
        }
    }
}
