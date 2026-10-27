using System;
using WebApiTest.Services.Generic;
using WebApiTest.Services.Interfaces;

namespace WebApiTest.Services.Repos;

public class CustomerRepository : ICustomerRepository
{
    private readonly ShopDbContext _context;
    private readonly IAsyncRepo<Customer> _asyncRepo;
    public CustomerRepository(ShopDbContext context, IAsyncRepo<Customer> asyncRepo)
    {
        _context = context;
        _asyncRepo = asyncRepo;
    }
    public async Task<Customer> AddAsync(Customer entity)
    {
        await _asyncRepo.AddAsync(entity);
        return entity;
    }

    public async Task DeleteAsync(int id)
    {
        await _asyncRepo.DeleteAsync(id);
    }

    public async Task<IList<Customer>> GetAllAsync()
    {
        return await _asyncRepo.GetAllAsync();
    }

    public async Task<Customer> GetByIdAsync(int id)
    {
        return await _context.Customers.FindAsync(id);
    }

    public async Task<Customer> UpdateAsync(Customer entity)
    {
        await _asyncRepo.UpdateAsync(entity);
        return entity;
    }
}
