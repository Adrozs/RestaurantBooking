using System.ComponentModel.DataAnnotations;

namespace RestaurantBooking.Models.DTOs
{
    public class CreateTableDTO
    {
        public int TableNumber { get; set; }

        public int Seats { get; set; }
    }
}
