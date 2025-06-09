using AutoMapper;
using ProductService.Application.Features.Products.Commands;
using ProductService.Domain.Entities;

namespace ProductService.Application.Mappings;

public class ProductMappingProfile : Profile
{
    public ProductMappingProfile()
    {
        CreateMap<CreateProductCommand, Product>();
        CreateMap<UpdateProductCommand, Product>();
    }
}

