using CustomerStorage.ViewModels.CustomerModels;

namespace CustomerStorage.Services.Services.Interfaces
{
    public interface ICustomerService
    {
        Task AddAsync(CreateCustomerViewModel model);
        Task<CustomerViewModel> ReadByIdAsync(int customerId);
        Task<List<CustomerViewModel>> GetListAsync();
        Task UpdateAsync(UpdateCustomerViewModel model);
        Task RemoveAsync(int customerId);
        Task TrancateAsync(int customerId);
        Task<List<CustomerViewModel>> GetByFilter(GetCustomersByFilterRequestModel requestModel);
    }
}
