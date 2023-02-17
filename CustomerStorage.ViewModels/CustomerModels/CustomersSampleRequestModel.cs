using CustomerStorage.DataAccessLayer.Enums;

namespace CustomerStorage.ViewModels.CustomerModels
{
    public class CustomersSampleRequestModel
    {
        public string SearchWord { get; set; }
        public CustomerOrderSettingsEnum SortingBy { get; set; }
        public bool ByAscending { get; set; }
        public int Page { get; set; }
        public int PageSize { get; set; }

        public CustomersSampleRequestModel()
        {
            SearchWord = String.Empty;
            SortingBy = CustomerOrderSettingsEnum.Name;
            ByAscending = true;
            Page = 1;
            PageSize = 10;
        }
    }
}
