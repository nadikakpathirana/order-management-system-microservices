using MediatR;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using ProductService.Domain.Entities;
using ProductService.Application.Interfaces;

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
        private readonly IMapper _mapper;

        public UpdateProductCommandHandler(IProductDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<int> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
        {
            var product = await _context.Products.Where(p => p.Id == request.Id)
                .FirstOrDefaultAsync(cancellationToken);
            
            if (product == null)
            {
                throw new KeyNotFoundException($"Product with ID {request.Id} not found.");
            }

            var updatedProduct = _mapper.Map<Product>(request);
            await _context.SaveChangesAsync();

            return product.Id;
        }
    }
}