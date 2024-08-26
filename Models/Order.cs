using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RestaurantBooking.Models
{
    public class Order
    {
        [Key]
        public int Id { get; set; }

        public int? Bill { get; set; }



        // Foreign keys

        [Required]
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }


        // Navigation property to OrderDishes for many-to-many relationship
        public ICollection<OrderDish> OrderDishes { get; set; }


    }
}
