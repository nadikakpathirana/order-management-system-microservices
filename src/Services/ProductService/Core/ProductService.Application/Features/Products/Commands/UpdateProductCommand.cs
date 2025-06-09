using MediatR;
using ProductService.Application.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ProductService.Application.Features.Products.Commands;

public class UpdateProductCommand : IRequest<int>
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public decimal Rate { get; set; }

    internal sealed class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommand, int>
    {
        private readonly IProductDbContext _context;

        public UpdateProductCommandHandler(IProductDbContext context)
        {
            _context = context;
        }

        public async Task<int> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
        {
            var product = await _context.Products.Where(p => p.Id == request.Id)
                .FirstOrDefaultAsync(cancellationToken);
            
            if (product == null)
            {
                throw new KeyNotFoundException($"Product with ID {request.Id} not found.");
            }

            product.Name = request.Name;
            product.Description = request.Description;
            product.Rate = request.Rate;

            await _context.SaveChangesAsync();

            return product.Id;
        }
    }
}