using Microsoft.EntityFrameworkCore.Metadata.Internal;
using RestaurantBooking.Data.Repos.IRepos;
using RestaurantBooking.Models;
using RestaurantBooking.Models.DTOs.CustomerDTOs;
using RestaurantBooking.Services.IServices;

namespace RestaurantBooking.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepo _customerRepo;

        public CustomerService(ICustomerRepo customerRepo)
        {
            _customerRepo = customerRepo;
        }

        public async Task<int> CreateCustomerAsync(CreateCustomerDTO customer)
        {
            var newCustomer = new Customer
            {
                Name = customer.Name,
                PhoneNumber = customer.PhoneNumber,
            };

            // Returns customer id
            return await _customerRepo.CreateCustomerAsync(newCustomer); 
        }



        public async Task<IEnumerable<CustomerDTO>> GetAllCustomersAsync()
        {
            var customers = await _customerRepo.GetAllCustomersAsync();

            // Map the customer object to the dto using the select like a foreach and make it a list
            return customers.Select(c => new CustomerDTO
            {
                Id = c.Id,
                Name = c.Name,
                PhoneNumber = c.PhoneNumber,
            }).ToList();

        }

        public async Task<CustomerDTO> GetCustomerByIdAsync(int customerId)
        {
            var customer = await _customerRepo.GetCustomerByIdAsync(customerId);
            if (customer == null)
                return null;

            return new CustomerDTO
            { 
                Id = customer.Id,
                Name = customer.Name, 
                PhoneNumber = customer.PhoneNumber 
            };
        }

        public async Task UpdateCustomerAsync(CustomerDTO updatedCustomer)
        {
            // Get existing customer object
            var customer = await _customerRepo.GetCustomerByIdAsync(updatedCustomer.Id);
            if (customer == null)
                throw new InvalidOperationException("Customer was not found.");

            // Assign new data
            customer.Name = updatedCustomer.Name;
            customer.PhoneNumber = updatedCustomer.PhoneNumber;
            
            // Update customer object
            await _customerRepo.UpdateCustomerAsync(customer); 
        }

        public async Task DeleteCustomerAsync(int customerId)
        {
            // Get existing customer object
            var customer = await _customerRepo.GetCustomerByIdAsync(customerId);
            if (customer == null)
                throw new InvalidOperationException("Customer was not found.");

            await _customerRepo.DeleteCustomerAsync(customer);
        }
    }
}