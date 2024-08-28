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

        public DateTime? ReservedUntil { get; set; }


        public ICollection<Reservation> Reservations { get; set;}

    }
}
