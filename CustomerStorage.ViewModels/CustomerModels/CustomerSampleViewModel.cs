
namespace CustomerStorage.ViewModels.CustomerModels
{
    public class CustomerSampleViewModel
    {
        public List<CustomerViewModel> Customers { get; set; }
        public int PagesCount { get; set; }
        public CustomerSampleViewModel()
        {
            Customers = new List<CustomerViewModel>();
        }
    }
}
