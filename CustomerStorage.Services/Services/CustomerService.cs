using CustomerStorage.DataAccessLayer.Entities;
using CustomerStorage.DataAccessLayer.Repositories.Interfaces;
using CustomerStorage.Services.DataMapping;
using CustomerStorage.Services.Services.Interfaces;
using CustomerStorage.ViewModels.CustomerModels;

namespace CustomerStorage.Services.Services
{
    public class CustomerService : ICustomerInterface
    {
        private readonly ICustomerRepository _customerRepository;

        public CustomerService(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public async Task AddAsync(CreateCustomerViewModel model)
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
            var viewModels = new List<CustomerViewModel>();

            foreach(var customer in customers)
            {
                CustomerViewModel viewModel = customer.MapEntityToViewModel();
                viewModels.Add(viewModel);
            };
            return viewModels;

        }
        public async Task UpdateAsync(UpdateCustomerViewModel model)
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
    }
}
