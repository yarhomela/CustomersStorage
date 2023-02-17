using CustomerStorage.ViewModels.CustomerModels;

namespace CustomerStorage.Services.Services.Interfaces
{
    public interface ICustomerService
    {
        Task AddAsync(CustomerCreateModel model);
        Task<CustomerViewModel> ReadByIdAsync(int customerId);
        Task<List<CustomerViewModel>> GetListAsync();
        Task UpdateAsync(CustomerUpdateModel model);
        Task RemoveAsync(int customerId);
        Task TrancateAsync(int customerId);
        Task<CustomersSampleResponseModel> GetByFilter(CustomersSampleRequestModel requestModel);
        Task<List<string>> GetAllCustomersNames();
    }
}
