using System.ComponentModel.DataAnnotations;

namespace RestaurantBooking.Models.DTOs.CustomerDTOs
{
    public class CustomerNoIdDTO
    {
        public string Name { get; set; }

        public string PhoneNumber { get; set; }
    }
}
