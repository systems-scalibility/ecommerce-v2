using ecommerce_v2.Db;
using ecommerce_v2.Models;
using Microsoft.EntityFrameworkCore;

namespace ecommerce_v2.Services;

public class Repository<T> : IRepository<T> where T : Base
{
    private readonly AppDbContext _context;

    public Repository(AppDbContext context)
    {
        _context = context;
    }

    public IQueryable<T> GetAll()
    {
        return _context.Set<T>()
            .AsNoTracking();
    }

    public async Task<T?> GetById(int id)
    {
        return await _context.Set<T>().FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task<T?> GetByRowGuid(Guid rowGuid)
    {
        return await _context.Set<T>().FirstOrDefaultAsync(x => x.RowGuid == rowGuid);
    }

    public async Task<T> Add(T entity)
    {
        entity.DateCreated = DateTime.Now;
        var entityCreated = await _context.Set<T>().AddAsync(entity);
        await _context.SaveChangesAsync();
        return entityCreated.Entity;
    }

    public async Task<T> Update(T entity)
    {
        entity.DateUpdated = DateTime.Now;
        var entityUpdated = _context.Set<T>().Update(entity);
        await _context.SaveChangesAsync();
        return entityUpdated.Entity;
    }

    public async Task DeleteById(int id)
    {
        var entity = await _context.Set<T>().FirstOrDefaultAsync(x => x.Id == id);
        if (entity != null)
        {
            _context.Set<T>().Remove(entity);
            await _context.SaveChangesAsync();
        }
    }

    public async Task DeleteByRowGuid(Guid rowGuid)
    {
        var entity = await _context.Set<T>().FirstOrDefaultAsync(x => x.RowGuid == rowGuid);
        if (entity != null)
        {
            _context.Set<T>().Remove(entity);
            await _context.SaveChangesAsync();
        }
    }
}