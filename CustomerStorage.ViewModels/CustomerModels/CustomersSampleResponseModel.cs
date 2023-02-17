
namespace CustomerStorage.ViewModels.CustomerModels
{
    public class CustomersSampleResponseModel
    {
        public List<CustomerViewModel> Customers { get; set; }
        public int PagesCount { get; set; }
        public CustomersSampleResponseModel()
        {
            Customers = new List<CustomerViewModel>();
        }
    }
}
