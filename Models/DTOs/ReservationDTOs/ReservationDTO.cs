namespace RestaurantBooking.Models.DTOs.ReservationDTOs
{
    public class ReservationDTO
    {
        public int Id { get; set; }
        public DateTime ReservationTime { get; set; }
        public int Guests { get; set; }

        public int TableId { get; set; }
        public int CustomerId { get; set; }
    }
}
