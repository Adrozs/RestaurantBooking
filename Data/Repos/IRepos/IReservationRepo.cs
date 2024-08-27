using Microsoft.AspNetCore.Mvc;
using RestaurantBooking.Models;

namespace RestaurantBooking.Data.Repos.IRepos
{
    public interface IReservationRepo
    {
        public Task CreateReservationAsync(Reservation res);
        public Task<IEnumerable<Reservation>> GetAllReservationsAsync();
        public Task<Reservation> GetReservationByIdAsync(int resId);
        public Task UpdateReservationAsync(Reservation res);
        public Task DeleteReservationAsync(Reservation res);
    }
}
