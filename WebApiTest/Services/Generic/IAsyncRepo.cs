using System;

namespace WebApiTest.Services.Generic;

public interface IAsyncRepo<T> where T : class
{
    Task AddAsync(T entity);
    Task UpdateAsync(T entity);
    Task DeleteAsync(int id);
    Task<List<T>> GetAllAsync();
}
