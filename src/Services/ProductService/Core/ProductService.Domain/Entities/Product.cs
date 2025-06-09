using ProductService.Domain.BaseEntities;

namespace ProductService.Domain.Entities;

public class Product : BaseEntity
{
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public decimal Rate { get; set; }
}