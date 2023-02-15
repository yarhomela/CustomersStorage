using CustomerStorage.DataAccessLayer.Entities;

namespace CustomerStorage.DataAccessLayer.DTO
{
    public class CustomerSampleDTO
    {
        public List<Customer> Customers { get; set; }
        public int PagesCount { get; set; }
        public CustomerSampleDTO()
        {
            Customers = new List<Customer>();
        }
    }
}
