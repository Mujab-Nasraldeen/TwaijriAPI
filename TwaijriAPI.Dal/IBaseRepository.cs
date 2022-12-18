using System.Linq.Expressions;

namespace TwaijriAPI.Dal;
public interface IBaseRepository<T> where T : class
{
    Task<IEnumerable<T>> GetAllAsync();
    IQueryable<T> GetAll();
    Task<T> GetAsync(Expression<Func<T, bool>> expression);
    Task<T> GetByIdAsync(Guid id);
    IQueryable<T> GetMany(Expression<Func<T, bool>> expression);
    Task AddAsync(T entity);
    Task AddRangeAsync(IEnumerable<T> entities);
    void UpdateAsync(T entity);
    void DeleteAsync(T entity);
    void DeleteAsync(IEnumerable<T> entities);
}
