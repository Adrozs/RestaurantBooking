using RestaurantBooking.Models;
using RestaurantBooking.Models.DTOs.ReservationDTOs;

namespace RestaurantBooking.Services.IServices
{
    public interface IReservationService
    {
        public Task CreateReservationAsync(CreateReservationDTO res);
        public Task<IEnumerable<ReservationDTO>> GetAllReservationsAsync();
        public Task<ReservationDTO> GetReservationByIdAsync(int resId);
        public Task UpdateReservationAsync(ReservationDTO res);
        public Task DeleteReservationAsync(int resId);
    }
}
