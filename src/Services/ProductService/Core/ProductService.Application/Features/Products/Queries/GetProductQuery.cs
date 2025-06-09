using MediatR;
using Microsoft.EntityFrameworkCore;
using ProductService.Application.Interfaces;
using ProductService.Domain.Entities;

namespace ProductService.Application.Features.Products.Queries;

public class GetProductQuery : IRequest<Product?>
{
    public int Id { get; set; }

    internal sealed class GetProductQueryHandler : IRequestHandler<GetProductQuery, Product?>
    {
        private readonly IProductDbContext _context;

        public GetProductQueryHandler(IProductDbContext context)
        {
            _context = context;
        }

        public async Task<Product?> Handle(GetProductQuery request, CancellationToken cancellationToken)
        {
            var result = await _context.Products.Where(p => p.Id == request.Id)
                .AsNoTracking()
                .FirstOrDefaultAsync(cancellationToken);

            return result;
        }
    }
}
