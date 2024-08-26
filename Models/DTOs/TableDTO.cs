using System.ComponentModel.DataAnnotations;

namespace RestaurantBooking.Models.DTOs
{
    public class TableDTO
    {
        public int Id { get; set; }
        public int TableNumber { get; set; }
        public int Seats { get; set; }
        public bool IsReserved { get; set; }
    }
}
