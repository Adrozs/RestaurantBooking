using System.ComponentModel.DataAnnotations;

namespace RestaurantBooking.Models
{
    public class Order
    {
        [Key]
        public int Id { get; set; }

        public string? SpecialInstructions { get; set; }


        // Foreign keys
        [Required]
        public int ReservationId { get; set; }
        public Reservation Reservation { get; set; }

        [Required]
        public int DishId { get; set; }
        public Dish Dish { get; set; }
    }
}
