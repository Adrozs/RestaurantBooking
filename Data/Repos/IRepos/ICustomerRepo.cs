using RestaurantBooking.Models;

namespace RestaurantBooking.Data.Repos.IRepos
{
    public interface ICustomerRepo
    {
        public Task CreateCustomerAsync(Customer customer);
        public Task<IEnumerable<Customer>> GetAllCustomersAsync();
        public Task<Customer> GetCustomerByIdAsync(int customerId);
        public Task UpdateCustomerAsync(Customer customer);
        public Task DeleteCustomerAsync(Customer customer);
    }
}
