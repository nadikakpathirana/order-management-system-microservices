using MediatR;
using AutoMapper;
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
        private readonly IMapper _mapper;

        public CreateProductCommandHandler(IProductDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<int> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            var product = _mapper.Map<Product>(request);
            await _context.Products.AddAsync(product, cancellationToken);
            await _context.SaveChangesAsync();

            return product.Id;
        }
    }
}