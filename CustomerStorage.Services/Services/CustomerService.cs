using CustomerStorage.DataAccessLayer.Entities;
using CustomerStorage.DataAccessLayer.Repositories.Interfaces;
using CustomerStorage.Services.DataMapping;
using CustomerStorage.Services.Services.Interfaces;
using CustomerStorage.ViewModels.CustomerModels;

namespace CustomerStorage.Services.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository _customerRepository;

        public CustomerService(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public async Task AddAsync(CustomerCreateModel model)
        {
            Customer customer = model.MapCreateModelToEntity();
            await _customerRepository.CreateAsync(customer);
        }
        public async Task<CustomerViewModel> ReadByIdAsync(int customerId)
        {
            Customer customer = await _customerRepository.ReadByIdAsync(customerId);
            CustomerViewModel viewModel = customer.MapEntityToViewModel();
            return  viewModel;
        }
        public async Task<List<CustomerViewModel>> GetListAsync()
        {
            List<Customer> customers = await _customerRepository.GetCustomersAsync();
            var customerList = new List<CustomerViewModel>();

            foreach(var customer in customers)
            {
                CustomerViewModel viewModel = customer.MapEntityToViewModel();
                customerList.Add(viewModel);
            };
            return customerList;

        }
        public async Task UpdateAsync(CustomerUpdateModel model)
        {
            Customer customer = model.MapUpdateModelToEntity();
            await _customerRepository.UpdateAsync(customer);
        }
        public async Task RemoveAsync(int customerId)
        {
            await _customerRepository.SetIsRemovedAsync(customerId);
        }
        public async Task TrancateAsync(int customerId)
        {
            await _customerRepository.DeleteAsync(customerId);
        }
        public async Task<CustomersSampleResponseModel> GetByFilter(CustomersSampleRequestModel requestModel)
        {
            var requestDto = requestModel.MapModelToRequestDto();
            var resultDto = await _customerRepository.GetCustomersByFiler(requestDto);

            var responseModel = new CustomersSampleResponseModel();
            responseModel.PagesCount = resultDto.PagesCount;

            foreach (var customer in resultDto.Customers)
            {
                CustomerViewModel viewModel = customer.MapEntityToViewModel();
                responseModel.Customers.Add(viewModel);
            };
            return responseModel;
        }
        public async Task<List<string>> GetAllCustomersNames()
        {
            var customerList = await _customerRepository.GetAllCustomersNames();
            return customerList;
        }
    }
}
