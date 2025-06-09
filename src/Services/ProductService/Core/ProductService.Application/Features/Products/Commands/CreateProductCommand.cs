using System;
using MediatR;
using System.Security.Cryptography;
using ProductService.Domain.Entities;

namespace ProductService.Application.Features.Products.Commands;

public class CreateProductCommand : IRequest<int>
{
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public decimal Rate { get; set; }

    internal sealed class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, int>
    {
        public async Task<int> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            // Logic to create a product

            // Simulate saving to a database and returning the new product ID
            int newProductId = RandomNumberGenerator.GetInt32(1, 1000);

            return await Task.FromResult(newProductId);
        }
    }
}