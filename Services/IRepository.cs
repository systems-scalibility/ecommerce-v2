namespace ecommerce_v2.Services;

public interface IRepository<T> where T : class
{
    IQueryable<T> GetAll();
    Task<T?> GetById(int id);
    Task<T?> GetByRowGuid(Guid rowGuid);
    Task<T> Add(T entity);
    Task<T> Update(T entity);
    Task DeleteById(int id);
    Task DeleteByRowGuid(Guid rowGuid);
}