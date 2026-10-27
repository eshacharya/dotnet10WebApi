using System;
using WebApiTest.Services.Generic;
using WebApiTest.Services.Interfaces;

namespace WebApiTest.Services.Repos;

public class ProductRepository : IProductRepository
{
    private readonly ShopDbContext _context;
    private readonly IAsyncRepo<Product> _asyncRepo;
    public ProductRepository(ShopDbContext context, IAsyncRepo<Product> asyncRepo)
    {
        _context = context;
        _asyncRepo = asyncRepo;
    }
    public async Task<Product> AddAsync(Product entity)
    {
        await _asyncRepo.AddAsync(entity);
        return entity;
    }

    public async Task DeleteAsync(int id)
    {
        await _asyncRepo.DeleteAsync(id);
    }

    public async Task<IList<Product>> GetAllAsync()
    {
        return await _asyncRepo.GetAllAsync();
    }

    public async Task<Product> GetByIdAsync(int id)
    {
        return await _context.Products.FindAsync(id);
    }

    public async Task<Product> UpdateAsync(Product entity)
    {
        await _asyncRepo.UpdateAsync(entity);
        return entity;
    }

}
