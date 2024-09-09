using System.ComponentModel.DataAnnotations;

namespace RestaurantBooking.Models.DTOs.DishDTOs
{
    public class DishDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public bool IsAvailable { get; set; }
    }
}
