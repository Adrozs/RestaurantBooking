using System.ComponentModel.DataAnnotations;

namespace RestaurantBooking.Models.DTOs
{
    public class UserCredsDto
    {
        [Required]
        public string Username { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
