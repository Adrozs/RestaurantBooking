namespace RestaurantBooking.Models.DTOs.TableDTOs
{
    public class AvailableTableTimesReqDTO
    {
        public int NumberOfGuests { get; set; }
        public DateTime SelectedDate { get; set; }
    }
}
