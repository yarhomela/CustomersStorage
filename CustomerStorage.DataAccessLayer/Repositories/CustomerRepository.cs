using CustomerStorage.DataAccessLayer.Entities;
using CustomerStorage.DataAccessLayer.Repositories.Base;
using Microsoft.EntityFrameworkCore;

namespace CustomerStorage.DataAccessLayer.Repositories
{
    public class CustomerRepository : BaseRepository<Customer>
    {
        private readonly ApplicationDbContext _context;
        public CustomerRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<IList<Customer>> GetCustomers()
        {
            var customers = await _context.Customers
                .AsNoTracking()
                .ToListAsync();
            return customers;
        }
    }
}
