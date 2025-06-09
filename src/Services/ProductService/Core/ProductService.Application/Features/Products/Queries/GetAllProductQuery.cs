using MediatR;
using Microsoft.EntityFrameworkCore;
using ProductService.Application.Interfaces;
using ProductService.Domain.Entities;

namespace ProductService.Application.Features.Products.Queries;

public class GetAllProductQuery : IRequest<IEnumerable<Product>>
{
    internal sealed class GetAllProductQueryHandler : IRequestHandler<GetAllProductQuery, IEnumerable<Product>>
    {
        private readonly IProductDbContext _context;

        public GetAllProductQueryHandler(IProductDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Product>> Handle(GetAllProductQuery request, CancellationToken cancellationToken)
        {
            var result = await _context.Products
                .AsNoTracking()
                .ToListAsync(cancellationToken);

            return result;
        }
    }
}
