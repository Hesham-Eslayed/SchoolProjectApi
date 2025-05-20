using Microsoft.EntityFrameworkCore.Storage;

using SchoolProject.Domain.Interfaces.Persistence;

namespace SchoolProject.Infrastructure.InfarstructureBases;

public class GenericRepository<T>(AppDbContext _dbContext) : IGenericRepository<T> where T : class
{

    #region Actions

    public virtual async Task<T?> GetByIdAsync(int id) => await _dbContext.Set<T>().FindAsync(id);


    public IQueryable<T> GetTableNoTracking() => _dbContext.Set<T>().AsNoTrackingWithIdentityResolution().AsQueryable();


    public virtual async Task AddRangeAsync(ICollection<T> entities)
    {
        await _dbContext.Set<T>().AddRangeAsync(entities);
        await _dbContext.SaveChangesAsync();
    }

    public virtual async Task<T?> AddAsync(T entity)
    {
        await _dbContext.Set<T>().AddAsync(entity);
        await _dbContext.SaveChangesAsync();

        return entity;
    }

    public virtual async Task<bool> UpdateAsync(T entity)
    {
        _dbContext.Entry(entity).State = EntityState.Modified;

        return await _dbContext.SaveChangesAsync() > 0;
    }

    public virtual async Task<bool> DeleteAsync(T entity)
    {
        _dbContext.Entry(entity).State = EntityState.Deleted;
        return await _dbContext.SaveChangesAsync() > 0;
    }

    public virtual async Task DeleteRangeAsync(ICollection<T> entities)
    {
        foreach (var entity in entities)
        {
            _dbContext.Entry(entity).State = EntityState.Deleted;
        }
        await _dbContext.SaveChangesAsync();
    }

    public async Task SaveChangesAsync() => await _dbContext.SaveChangesAsync();



    public IDbContextTransaction BeginTransaction() => _dbContext.Database.BeginTransaction();

    public void Commit() => _dbContext.Database.CommitTransaction();

    public void RollBack() => _dbContext.Database.RollbackTransaction();

    public IQueryable<T> GetTableAsTracking() => _dbContext.Set<T>().AsQueryable();

    public virtual async Task UpdateRangeAsync(ICollection<T> entities)
    {
        _dbContext.Set<T>().UpdateRange(entities);
        await _dbContext.SaveChangesAsync();
    }

    #endregion Actions
}