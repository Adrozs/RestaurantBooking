using System.ComponentModel.DataAnnotations;

namespace RestaurantBooking.Models.DTOs.OrderDTOs
{
    public class CreateOrderDTO
    {
        public string? SpecialInstructions { get; set; }


        public int DishId { get; set; }

        public int ReservationId { get; set; }
    }
}
