using System;
using Microsoft.EntityFrameworkCore;
using WebApiTest.Services.Generic;

namespace WebApiTest.Services.Repos;

public class EFRepo<T> : IAsyncRepo<T> where T : class
{
    private readonly ShopDbContext _context;
    private readonly DbSet<T> _dbSet;


    public EFRepo(ShopDbContext context)
    {
        _context = context;
        _dbSet = _context.Set<T>();
    }

    public async Task AddAsync(T entity)
    {
        _dbSet.Add(entity);
        await SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var entity = await _dbSet.FindAsync(id);

        if (entity is not null)
        {
            _dbSet.Remove(entity);
            await SaveChangesAsync();
        }
    }

    public async Task<List<T>> GetAllAsync()
    {
        return await _dbSet.ToListAsync();
    }

    public async Task UpdateAsync(T entity)
    {
        _dbSet.Update(entity);
        await SaveChangesAsync();
    }

    private async Task SaveChangesAsync()
    {
        await _context.SaveChangesAsync();
    }
}
