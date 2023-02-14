using CustomerStorage.DataAccessLayer.DTO;
using CustomerStorage.DataAccessLayer.Entities;
using CustomerStorage.DataAccessLayer.Repositories.Base;
using CustomerStorage.DataAccessLayer.Repositories.Interfaces;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Data;
using System.Reflection.PortableExecutable;

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

        public async Task<List<Customer>> GetCustomersByFiler(CustomersByFilterRequestDTO request)
        {
            string procedureName = "spSearchSortingPagingCustomers";
            var resultList = new List<Customer>();
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

                var reader = command.ExecuteReader();
                try
                {
                    while (reader.Read())
                    {
                        var customer = new Customer();
                        customer.Id = int.Parse(reader["Id"].ToString()!);
                        customer.Name = reader["Name"].ToString()!;
                        customer.CompanyName = reader["CompanyName"].ToString()!;
                        customer.Phone = reader["Phone"].ToString()!;
                        customer.Email = reader["Email"].ToString()!;

                        resultList.Add(customer);
                    }
                    return resultList;
                }
                catch (Exception ex)
                {
                    throw;
                }
                
            }

        }
    }
}
