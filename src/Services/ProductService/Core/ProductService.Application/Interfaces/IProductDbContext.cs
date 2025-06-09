using System;
using Microsoft.EntityFrameworkCore;
using ProductService.Domain.Entities;

namespace ProductService.Application.Interfaces;

public interface IProductDbContext
{
    DbSet<Product> Products { get; set; }

    Task<int> SaveChangesAsync();
}
