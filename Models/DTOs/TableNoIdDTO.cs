namespace RestaurantBooking.Models.DTOs
{
    public class TableNoIdDTO
    {
        public int TableNumber { get; set; }
        public int Seats { get; set; }
        public bool IsReserved { get; set; }
    }
}
