using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RestaurantBooking.Models
{
    public class Reservation
    {
        [Key] 
        public int Id { get; set; }

        [Required]
        public DateTime ReservationTime { get; set; }

        [Required]
        public int Guests { get; set; }


        
        // Foreign keys
        [Required]
        public int TableId { get; set; }
        public Table Table { get; set; }

        [Required]
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }
    }
}
