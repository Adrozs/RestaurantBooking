namespace RestaurantBooking.Models.DTOs.DishDTOs
{
    public class OrderedDishDTO
    {
        public int DishId { get; set; }
        public string DishName { get; set; }
        public decimal Price { get; set; }
        public string? SpecialInstructions { get; set; }
    }
}
