using System.ComponentModel.DataAnnotations;

namespace RestaurantBooking.Models.DTOs.CustomerDTOs
{
    public class CustomerDTO
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string PhoneNumber { get; set; }
    }
}
