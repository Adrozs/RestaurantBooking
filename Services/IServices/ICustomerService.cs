using RestaurantBooking.Models.DTOs.CustomerDTOs;

namespace RestaurantBooking.Services.IServices
{
    public interface ICustomerService
    {
        public Task CreateCustomerAsync(CreateCustomerDTO customer);
        public Task<IEnumerable<CustomerDTO>> GetAllCustomersAsync();
        public Task<CustomerDTO> GetCustomerByIdAsync(int customerId);
        public Task UpdateCustomerAsync(CustomerDTO customer);
        public Task DeleteCustomerAsync(int customerId);
    }
}
