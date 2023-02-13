using CustomerStorage.DataAccessLayer.DTO;
using CustomerStorage.DataAccessLayer.Entities;
using CustomerStorage.ViewModels.CustomerModels;

namespace CustomerStorage.Services.DataMapping
{
    public static class CustomerModelToEntityMapper
    {
        public static Customer MapCreateModelToEntity(this CreateCustomerViewModel model)
        {
            var customer = new Customer()
            {
                Name = model.Name,
                CompanyName = model.CompanyName,
                Phone = model.Phone,
                Email = model.Email
            };
            return customer;
        }

        public static Customer MapUpdateModelToEntity(this UpdateCustomerViewModel model)
        {
            var customer = new Customer()
            {
                Id = model.CustomerId,
                Name = model.Name,
                CompanyName = model.CompanyName,
                Phone = model.Phone,
                Email = model.Email
            };
            return customer;
        }

        public static CustomerViewModel MapEntityToViewModel(this Customer customer)
        {
            var viewModel = new CustomerViewModel()
            {
                CustomerId = customer.Id,
                Name = customer.Name,
                CompanyName = customer.CompanyName,
                Phone = customer.Phone,
                Email = customer.Email
            };
            return viewModel;
        }

        public static CustomersByFilterRequestDTO MapModelToRequestDto(this GetCustomersByFilterRequestModel requestModel)
        {
            var requestDto = new CustomersByFilterRequestDTO()
            {
                SearchWord = requestModel.SearchWord,
                SortingBy = requestModel.SortingBy,
                ByAscending = requestModel.ByAscending,
                Page = requestModel.Page,
                PageSize = requestModel.PageSize
            };
            return requestDto;
        }
    }
}
