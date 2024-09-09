namespace RestaurantBooking.Models.DTOs.DishDTOs
{
    public class CreateDishDTO
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }

        // Keeping is availaible in the create dto to give the option to the admin to select if a dish should be available or not when created to allow for flexibility to add dishes maybe in an "upcoming" section or similar
        public bool IsAvailable { get; set; } 
    }
}
