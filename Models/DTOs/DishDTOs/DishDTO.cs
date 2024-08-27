using System.ComponentModel.DataAnnotations;

namespace RestaurantBooking.Models.DTOs.DishDTOs
{
    public class DishDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }
        public bool IsAvailable { get; set; }
    }
}
