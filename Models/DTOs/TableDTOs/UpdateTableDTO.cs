namespace RestaurantBooking.Models.DTOs.TableDTOs
{
    public class UpdateTableDTO
    {
        public int Id { get; set; }
        public int TableNumber { get; set; }
        public int Seats { get; set; }
        public DateTime ReservedUntil { get; set; }
    }
}
