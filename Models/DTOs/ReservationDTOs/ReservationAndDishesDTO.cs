using RestaurantBooking.Models.DTOs.DishDTOs;

namespace RestaurantBooking.Models.DTOs.ReservationDTOs
{
    public class ReservationAndDishesDTO
    {
        public int Id { get; set; }
        public DateTime ReservationTime { get; set; }
        public int ReservationDurationMinutes { get; set; }
        public int Guests { get; set; }
        public string CustomerName { get; set; }
        public decimal TotalBill { get; set; }


        public IEnumerable<OrderedDishDTO> OrderedDishes { get; set; } 
        public int TableId { get; set; }
        public int CustomerId { get; set; }
    }
}
