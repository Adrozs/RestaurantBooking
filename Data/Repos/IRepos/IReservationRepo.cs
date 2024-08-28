using Microsoft.AspNetCore.Mvc;
using RestaurantBooking.Models;

namespace RestaurantBooking.Data.Repos.IRepos
{
    public interface IReservationRepo
    {
        public Task CreateReservationAsync(Reservation res);
        public Task<IEnumerable<Reservation>> GetAllReservationsAsync();
        public Task<IEnumerable<Reservation>> GetActiveReservationsAsync();
        public Task<Reservation> GetReservationByIdAsync(int resId);
        public Task<Reservation> GetReservationAndOrderedDishesByIdAsync(int resId);
        public Task UpdateReservationAsync(Reservation res);
        public Task DeleteReservationAsync(Reservation res);
        public Task<bool> IsTableAvailableAsync(int tableId, DateTime reqResTime, int reqResDurationMinutes);
    }
}
