using System;
using WebApiTest.Services.Interfaces;

namespace WebApiTest.Services.ServiceRepo;

public class CustomerService : ICustomerService
{
    private readonly ICustomerRepository _customerRepository;

    public CustomerService(ICustomerRepository customerRepository)
    {
        _customerRepository = customerRepository;
    }
    public async Task<Customer> AddCustomerAsync(Customer customer)
    {
        return await _customerRepository.AddAsync(customer);
    }

    public Task DeleteCustomerAsync(int id)
    {
        return _customerRepository.DeleteAsync(id);
    }

    public async Task<IList<Customer>> GetAllCustomersAsync()
    {
        return await _customerRepository.GetAllAsync();
    }

    public async Task<Customer> GetCustomerByIdAsync(int id)
    {
        return await _customerRepository.GetByIdAsync(id);
    }

    public async Task<Customer> UpdateCustomerAsync(Customer customer)
    {
        return await _customerRepository.UpdateAsync(customer);
    }
}
