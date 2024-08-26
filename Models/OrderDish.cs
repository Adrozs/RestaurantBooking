using System.ComponentModel.DataAnnotations;

namespace RestaurantBooking.Models
{

    // Created a specific class for the many-to-many relationship between order and dishes for future proofing in case we want to add more props to this later
    // Otherwise EF will create this automatically

    public class OrderDish
    {
        [Key]
        public int Id { get; set; }


        // Foreign keys
        [Required]
        public int OrderId { get; set; }
        public Order Order { get; set; }

        [Required]
        public int DishId { get; set; }
        public Dish Dish { get; set; }
    }
}
