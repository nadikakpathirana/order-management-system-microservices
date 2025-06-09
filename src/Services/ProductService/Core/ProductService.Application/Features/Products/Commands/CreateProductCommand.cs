using MediatR;
using ProductService.Domain.Entities;
using ProductService.Application.Interfaces;

namespace ProductService.Application.Features.Products.Commands;

public class CreateProductCommand : IRequest<int>
{
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public decimal Rate { get; set; }

    internal sealed class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, int>
    {
        private readonly IProductDbContext _context;

        public CreateProductCommandHandler(IProductDbContext context)
        {
            _context = context;
        }

        public async Task<int> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            var product = new Product
            {
                Name = request.Name,
                Description = request.Description,
                Rate = request.Rate
            };

            await _context.Products.AddAsync(product, cancellationToken);
            await _context.SaveChangesAsync();

            return product.Id;
        }
    }
}