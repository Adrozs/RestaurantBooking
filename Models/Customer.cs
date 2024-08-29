using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RestaurantBooking.Models
{
    public class Customer
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        [Required]
        [MaxLength(12)]
        public string PhoneNumber { get; set; }


        // Keeping nav prop in case want to add functionallity to access a customers reservations in the future
        public ICollection<Reservation> Reservations { get; set; }
    }
}
