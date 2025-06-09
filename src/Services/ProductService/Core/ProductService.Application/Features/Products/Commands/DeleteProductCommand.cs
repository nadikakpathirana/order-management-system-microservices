using MediatR;
using ProductService.Domain.Entities;
using ProductService.Application.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ProductService.Application.Features.Products.Commands;

public class DeleteProductCommand : IRequest<int>
{
    public int Id { get; set; }

    internal sealed class DeleteProductCommandHandler : IRequestHandler<DeleteProductCommand, int>
    {
        private readonly IProductDbContext _context;

        public DeleteProductCommandHandler(IProductDbContext context)
        {
            _context = context;
        }

        public async Task<int> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
        {
            var product = await _context.Products.Where(p => p.Id == request.Id)
                .FirstOrDefaultAsync(cancellationToken);
            
            if (product == null)
            {
                throw new KeyNotFoundException($"Product with ID {request.Id} not found.");
            }

            _context.Products.Remove(product);
            await _context.SaveChangesAsync();

            return request.Id;
        }
    }
}