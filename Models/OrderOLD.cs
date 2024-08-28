using System.ComponentModel.DataAnnotations;

namespace RestaurantBooking.Models
{
    public class OrderOLD
    {
        [Key]
        public int Id { get; set; }

        public decimal TotalBill { get; set; }



        // Foreign keys

        // Order connected to the reservation which in turn connects to both the table and the customer
        [Required]
        public int ReservationId { get; set; }
        public Reservation Reservation { get; set; }


        // Navigation property to OrderDishes for many-to-many relationship
        // Represents all dishes ordered
        //public ICollection<OrderDish> OrderDishes { get; set; }


    }
}
