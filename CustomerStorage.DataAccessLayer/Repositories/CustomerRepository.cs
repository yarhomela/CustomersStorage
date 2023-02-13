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

        public async Task<List<Customer>> GetCustomersByFiler(CustomersByFilterRequestDTO request)
        {
            string procedureName = "spSearchSortingPagingCustomers";
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

                var sqlDataReader = command.ExecuteReader();
                var resultList = sqlDataReader.Cast<Customer>().ToList();
                return resultList;
            }

        }
    }
}
