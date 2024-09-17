using System.ComponentModel.DataAnnotations;

namespace RestaurantBooking.Models.DTOs.TableDTOs
{
    public class TableDTO
    {
        public int Id { get; set; }
        public int Seats { get; set; }
        public DateTime? ReservedUntil { get; set; }
    }
}
