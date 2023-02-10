using CustomerStorage.DataAccessLayer.Entities;

namespace CustomerStorage.DataAccessLayer.Repositories.Interfaces
{
    public interface ICustomerRepository
    {
        Task CreateAsync(Customer customer);
        Task CreateRangeAsync(List<Customer> customers);
        Task<Customer> ReadByIdAsync(int customerId);
        Task<List<Customer>> GetCustomersAsync();
        Task UpdateAsync(Customer customer);
        Task UpdateRangeAsync(List<Customer> customers);
        Task SetIsRemovedAsync(int entityId);
        Task DeleteAsync(int customerId);
    }
}
