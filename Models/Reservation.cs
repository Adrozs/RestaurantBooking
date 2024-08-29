using System.ComponentModel.DataAnnotations;

namespace RestaurantBooking.Models
{
    public class Reservation
    {
        [Key] 
        public int Id { get; set; }

        [Required]
        public DateTime ReservationTime { get; set; }
        public int ReservationDurationMinutes { get; set; }

        [Required]
        public int Guests { get; set; }

        public decimal TotalBill { get; set; }




        // Foreign keys
        [Required]
        public int TableId { get; set; }
        public Table Table { get; set; }

        [Required]
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }

        
        // Initialize list upon creation
        public ICollection<Order> Orders { get; set; } = new List<Order>();
    }
}
