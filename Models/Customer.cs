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


        // Nav props
        public ICollection<Reservation> Reservation { get; set; }
        public ICollection<Order> Order { get; set; }

    }
}
