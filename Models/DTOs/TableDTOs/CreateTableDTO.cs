using System.ComponentModel.DataAnnotations;

namespace RestaurantBooking.Models.DTOs.TableDTOs
{
    public class CreateTableDTO
    {
        public int TableNumber { get; set; }

        public int Seats { get; set; }
    }
}
