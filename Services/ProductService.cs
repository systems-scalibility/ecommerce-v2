using ecommerce_v1.Db;
using ecommerce_v1.Models;
using Microsoft.EntityFrameworkCore;

namespace ecommerce_v1.Services;

public class ProductService(AppDbContext context)
{
    public async Task<IEnumerable<Product?>> GetAll()
    {
        return await context.Products.ToListAsync();
    }

    public async Task<Product?> GetById(int id)
    {
        return await context.Products.FindAsync(id);
    }

    public async Task<Product> Add(Product entity)
    {
        var productCreated = await context.Products.AddAsync(entity);
        await context.SaveChangesAsync();
        return productCreated.Entity;
    }

    public async Task<Product> Update(Product entity)
    {
        context.Products.Update(entity);
        await context.SaveChangesAsync();
        return entity;
    }

    public async Task Delete(int id)
    {
        var product = await context.Products.FindAsync(id);
        if (product != null) context.Products.Remove(product);
        await context.SaveChangesAsync();
    }
}