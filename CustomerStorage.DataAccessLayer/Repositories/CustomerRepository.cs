using CustomerStorage.DataAccessLayer.DTO;
using CustomerStorage.DataAccessLayer.Entities;
using CustomerStorage.DataAccessLayer.Repositories.Base;
using CustomerStorage.DataAccessLayer.Repositories.Interfaces;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Data;

namespace CustomerStorage.DataAccessLayer.Repositories
{
    public class CustomerRepository : BaseRepository<Customer>, ICustomerRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly string _connectionString = String.Empty;
        public CustomerRepository(ApplicationDbContext context, IConfiguration configuration) : base(context)
        {
            _context = context;
            _connectionString = configuration.GetConnectionString("DefaultConnection");
        }

        public async Task<List<Customer>> GetCustomersAsync()
        {
            var customers = await _context.Customers
                .AsNoTracking()
                .ToListAsync();
            return customers;
        }

        public async Task<CustomerSampleDTO> GetCustomersByFiler(CustomersByFilterRequestDTO request)
        {
            string procedureName = "spSearchSortingPagingCustomers";
            var customerModel = new CustomerSampleDTO();
            using (var connection = new SqlConnection(_connectionString))
            {
                var command = new SqlCommand(procedureName, connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@searchWord", request.SearchWord);
                command.Parameters.AddWithValue("@sortingBy", request.SortingBy);
                command.Parameters.AddWithValue("@byAscending", request.ByAscending);
                command.Parameters.AddWithValue("@page", request.Page);
                command.Parameters.AddWithValue("@pageSize", request.PageSize);

                await command.Connection.OpenAsync();

                var procedureReader = await command.ExecuteReaderAsync();
                try
                {
                    bool isRead;
                    for (var page = 1; page <= request.PageSize; page++)
                    {
                        isRead = await procedureReader.ReadAsync();
                        if (isRead)
                        {
                            var customer = new Customer();
                            customer.Id = int.Parse(procedureReader["Id"].ToString()!);
                            customer.Name = procedureReader["Name"].ToString()!;
                            customer.CompanyName = procedureReader["CompanyName"].ToString()!;
                            customer.Phone = procedureReader["Phone"].ToString()!;
                            customer.Email = procedureReader["Email"].ToString()!;

                            customerModel.Customers.Add(customer);
                        }
                    }

                    bool isResult = await procedureReader.NextResultAsync();
                    isRead = await procedureReader.ReadAsync();
                    if (isResult && isRead)
                    {
                        customerModel.PagesCount = procedureReader.GetInt32(0);
                    }
                    return customerModel;
                }
                catch (Exception ex)
                {
                    throw;
                }

            }

        }

        public async Task SetIsRemovedAsync(int entityId)
        {
            var customer = new Customer { Id = entityId, IsRemoved = true };

            try
            {
                _context.Attach(customer);
                _context.Entry(customer).Property(x => x.IsRemoved).IsModified = true;
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                throw new DbUpdateConcurrencyException(ex.Message);
            }
        }

        public async Task<List<string>> GetAllCustomersNames()
        {
            var allCustomersNames = await _context.Customers
                .AsNoTracking()
                .Select(x => x.Name)
                .ToListAsync();
            return allCustomersNames;
        }
    }
}
