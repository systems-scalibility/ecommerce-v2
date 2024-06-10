using ecommerce_v1.Db;
using ecommerce_v1.Models;
using Microsoft.EntityFrameworkCore;

namespace ecommerce_v1.Services;

public class SalesOrderService(AppDbContext context)
{
    public async Task<IEnumerable<SalesOrder?>> GetAll()
    {
        return await context.SalesOrders.ToListAsync();
    }

    public async Task<SalesOrder?> GetById(int id)
    {
        return await context.SalesOrders.FindAsync(id);
    }

    public async Task<SalesOrder> Add(SalesOrder entity)
    {
        var productCreated = await context.SalesOrders.AddAsync(entity);
        await context.SaveChangesAsync();
        return productCreated.Entity;
    }

    public async Task<SalesOrder> Update(SalesOrder entity)
    {
        context.SalesOrders.Update(entity);
        await context.SaveChangesAsync();
        return entity;
    }

    public async Task Delete(int id)
    {
        var salesOrder = await context.SalesOrders.FindAsync(id);
        if (salesOrder != null) context.SalesOrders.Remove(salesOrder);
        await context.SaveChangesAsync();
    }
}