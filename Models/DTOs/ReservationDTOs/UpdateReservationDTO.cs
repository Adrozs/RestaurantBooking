namespace RestaurantBooking.Models.DTOs.ReservationDTOs
{
    public class UpdateReservationDTO
    {
        public int Id { get; set; }
        public DateTime ReservationTime { get; set; }
        public int ReservationDurationMinutes { get; set; }
        public int Guests { get; set; }
        public decimal TotalBill { get; set; }

        public int TableId { get; set; }
        public int CustomerId { get; set; }
    }
}
