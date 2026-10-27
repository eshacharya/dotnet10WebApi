using System;

namespace WebApiTest.Services.Generic;

public interface IGenericRepo<T> where T : class
{
    Task<IList<T>> GetAllAsync();
    Task<T> GetByIdAsync(int id);
    Task<T> AddAsync(T entity);
    Task<T> UpdateAsync(T entity);
    Task DeleteAsync(int id);
}
