using System;
using WebApiTest.Services.Interfaces;

namespace WebApiTest.Services.ServiceRepo;

public class ProductService : IProductService
{
    private readonly IProductRepository _productRepository;
    public ProductService(IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }
    public async Task<Product> AddProductAsync(Product product)
    {
        return await _productRepository.AddAsync(product);
    }

    public async Task DeleteProductAsync(int id)
    {
        await _productRepository.DeleteAsync(id);
    }

    public async Task<IList<Product>> GetAllProductsAsync()
    {
        return await _productRepository.GetAllAsync();
    }

    public async Task<Product> GetProductByIdAsync(int id)
    {
        return await _productRepository.GetByIdAsync(id);
    }

    public async Task<Product> UpdateProductAsync(Product product)
    {
        return await _productRepository.UpdateAsync(product);
    }
}
