using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using RestaurantBooking.Models;
using RestaurantBooking.Models.DTOs.CustomerDTOs;
using RestaurantBooking.Services.IServices;
using System.Net;

namespace RestaurantBooking.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerService _customerService;

        public CustomerController(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        [HttpPost("CreateCustomer")]
        public async Task<ActionResult> CreateCustomerAsync([FromBody] CreateCustomerDTO customer)
        {
            try
            {
                var customerId = await _customerService.CreateCustomerAsync(customer);

                if (customerId == null)
                    return StatusCode(500, "An unexpected error occurred while creating customer.");

                return Ok(customerId);
            }
            catch (Exception ex)
            {
                return BadRequest("Failed to create customer: " + ex.Message);
            }

           
        }

        [HttpGet("GetAllCustomers")]
        public async Task<ActionResult> GetAllCustomersAsync()
        {
            var customers = await _customerService.GetAllCustomersAsync();

            if (customers.IsNullOrEmpty())
                return NotFound("No customers found.");

            return Ok(customers);
        }

        [HttpGet("GetCustomerById")]
        public async Task<ActionResult> GetCustomerByIdAsync([FromQuery] int customerId)
        {
            var customer = await _customerService.GetCustomerByIdAsync(customerId);
            if (customer == null)
                return NotFound("No matching customer found.");


            return Ok(customer);
        }

        [HttpPut("UpdateCustomer")]
        public async Task<ActionResult> UpdateCustomerAsync([FromBody] CustomerDTO customer)
        {
            try
            {
                await _customerService.UpdateCustomerAsync(customer);
            }
            catch (Exception ex)
            {
                return BadRequest("Failed to update customer. " + ex.Message);
            }

            return Ok("Customer updated successfully.");
        }

        [HttpDelete("DeleteCustomer")]
        public async Task<ActionResult> DeleteCustomerAsync([FromQuery] int customerId)
        {
            try
            {
                await _customerService.DeleteCustomerAsync(customerId);
            }
            catch(Exception ex)
            {
                return BadRequest("Failed to delete customer. " + ex.Message);
            }

            return Ok("Customer deleted successfully.");
        }
    }
}
