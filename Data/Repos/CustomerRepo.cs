using Microsoft.EntityFrameworkCore;
using RestaurantBooking.Data.Repos.IRepos;
using RestaurantBooking.Models;

namespace RestaurantBooking.Data.Repos
{
    public class CustomerRepo : ICustomerRepo
    {
        private readonly BookingDbContext _context;

        public CustomerRepo(BookingDbContext context)
        {
            _context = context;
        }


        public async Task<int> CreateCustomerAsync(Customer customer)
        {
            // Check if customer exists before creating new (unique identifier phone number)
            var existingCustomer = _context.Customers.SingleOrDefault(c => c.PhoneNumber == customer.PhoneNumber);

            // If customer exists return their id
            if (existingCustomer != null)
                return existingCustomer.Id;

            // Else create new customer and return their id
            await _context.AddAsync(customer);
            await _context.SaveChangesAsync();

            return customer.Id;
        }

        public async Task DeleteCustomerAsync(Customer customer)
        {
            _context.Customers.Remove(customer);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Customer>> GetAllCustomersAsync()
        {
            return await _context.Customers.ToListAsync();
        }

        public async Task<Customer> GetCustomerByIdAsync(int customerId)
        {
            return await _context.Customers.SingleOrDefaultAsync(c => c.Id == customerId);
        }

        public async Task UpdateCustomerAsync(Customer customer)
        {
            _context.Customers.Update(customer);
            await _context.SaveChangesAsync();
        }
    }
}
