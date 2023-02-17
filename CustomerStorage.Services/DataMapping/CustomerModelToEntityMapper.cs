using CustomerStorage.DataAccessLayer.DTO;
using CustomerStorage.DataAccessLayer.Entities;
using CustomerStorage.ViewModels.CustomerModels;

namespace CustomerStorage.Services.DataMapping
{
    public static class CustomerModelToEntityMapper
    {
        public static Customer MapCreateModelToEntity(this CustomerCreateModel model)
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

        public static Customer MapUpdateModelToEntity(this CustomerUpdateModel model)
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

        public static CustomersByFilterRequestDTO MapModelToRequestDto(this CustomersSampleRequestModel requestModel)
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
