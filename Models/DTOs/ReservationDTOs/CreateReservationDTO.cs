namespace RestaurantBooking.Models.DTOs.ReservationDTOs
{
    public class CreateReservationDTO
    {
        public DateTime ReservationTime { get; set; }
        public int ReservationDurationMinutes { get; set; }

        public int Guests { get; set; }

        public int TableId { get; set; }
        public int CustomerId { get; set; }
    }
}
