using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace TwaijriAPI.Dal;
public class BaseRepository<T> : IBaseRepository<T> where T : class
{
    protected readonly ApplicationDBContext _applicationDBContext;
    protected DbSet<T> DbSet { get; set; }

    public BaseRepository(ApplicationDBContext applicationDBContext)
    {
        _applicationDBContext = applicationDBContext;
        DbSet = _applicationDBContext.Set<T>();
    }

    public async Task AddAsync(T entity)
    {
        await DbSet.AddAsync(entity);
    }

    public async Task AddRangeAsync(IEnumerable<T> entities)
    {
        await DbSet.AddRangeAsync(entities);
    }

    public async Task<IEnumerable<T>> GetAllAsync()
    {
        return await DbSet.AsNoTracking().ToListAsync();
    }

    public IQueryable<T> GetAll()
    {
        return DbSet.AsNoTracking();
    }

    public IQueryable<T> GetMany(Expression<Func<T, bool>> expression)
    {
        return DbSet.Where(expression).AsQueryable();
    }

    public async Task<T> GetAsync(Expression<Func<T, bool>> expression)
    {
        return await DbSet.Where(expression).AsNoTracking().FirstOrDefaultAsync();
    }

    public async Task<T> GetByIdAsync(Guid id)
    {
        return await DbSet.FindAsync(id);
    }

    public void UpdateAsync(T entity)
    {
        DbSet.Attach(entity);
        _applicationDBContext.Entry(entity).State = EntityState.Modified;
    }

    public void DeleteAsync(T entity)
    {
        DbSet.Remove(entity);
    }

    public void DeleteAsync(IEnumerable<T> entities)
    {
        DbSet.RemoveRange(entities);
    }
}
