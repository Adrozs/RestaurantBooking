using RestaurantBooking.Models;
using RestaurantBooking.Models.DTOs.OrderDTOs;
using RestaurantBooking.Models.DTOs.ReservationDTOs;

namespace RestaurantBooking.Services.IServices
{
    public interface IReservationService
    {
        public Task AddDishToReservationAsync(OrderDTO order);
        public Task CreateReservationAsync(CreateReservationDTO res);
        public Task<IEnumerable<ReservationDTO>> GetAllReservationsAsync();
        public Task<IEnumerable<ReservationDTO>> GetActiveReservationsAsync();
        public Task<ReservationAndDishesDTO> GetReservationByIdAsync(int resId);
        public Task UpdateReservationAsync(ReservationDTO res);
        public Task DeleteReservationAsync(int resId);
    }
}
