using ecommerce_v1.Db;
using ecommerce_v1.Models;
using Microsoft.EntityFrameworkCore;

namespace ecommerce_v1.Services;

public class SalesOrderItemService(AppDbContext context)
{
    public async Task<IEnumerable<SalesOrderItem?>> GetAll()
    {
        return await context.SalesOrderItems.ToListAsync();
    }

    public async Task<SalesOrderItem?> GetById(int id)
    {
        return await context.SalesOrderItems.FindAsync(id);
    }

    public async Task<SalesOrderItem> Add(SalesOrderItem entity)
    {
        var productCreated = await context.SalesOrderItems.AddAsync(entity);
        await context.SaveChangesAsync();
        return productCreated.Entity;
    }

    public async Task<SalesOrderItem> Update(SalesOrderItem entity)
    {
        context.SalesOrderItems.Update(entity);
        await context.SaveChangesAsync();
        return entity;
    }

    public async Task Delete(int id)
    {
        var salesOrder = await context.SalesOrderItems.FindAsync(id);
        if (salesOrder != null) context.SalesOrderItems.Remove(salesOrder);
        await context.SaveChangesAsync();
    }
}