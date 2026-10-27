using System;

namespace WebApiTest.Services.Interfaces;

public interface IProductService
{
    Task<IList<Product>> GetAllProductsAsync();
    Task<Product> GetProductByIdAsync(int id);
    Task<Product> AddProductAsync(Product product);
    Task<Product> UpdateProductAsync(Product product);
    Task DeleteProductAsync(int id);

}
