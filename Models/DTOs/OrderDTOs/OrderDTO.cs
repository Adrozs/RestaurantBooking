namespace RestaurantBooking.Models.DTOs.OrderDTOs
{
    public class OrderDTO
    {
        public int DishId { get; set; }
        public int ReservationId { get; set; }
        public string? SpecialInstructions { get; set; }

    }
}
