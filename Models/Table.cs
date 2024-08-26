using System.ComponentModel.DataAnnotations;

namespace RestaurantBooking.Models
{
    public class Table
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int TableNumber { get; set; }

        [Required]
        public int Seats { get; set; }

        [Required]
        public bool IsReserved { get; set; } = false; // Tables aren't reserved when created

        public ICollection<Reservation> Reservations { get; set;}

    }
}
