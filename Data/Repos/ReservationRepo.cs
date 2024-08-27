using Microsoft.EntityFrameworkCore;
using RestaurantBooking.Data.Repos.IRepos;
using RestaurantBooking.Models;

namespace RestaurantBooking.Data.Repos
{
    public class ReservationRepo : IReservationRepo
    {
        private readonly BookingDbContext _context;

        public ReservationRepo(BookingDbContext context)
        {
            _context = context;
        }

        public async Task CreateReservationAsync(Reservation res)
        {
            _context.Reservations.Add(res);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteReservationAsync(Reservation res)
        {
            _context.Reservations.Remove(res);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Reservation>> GetAllReservationsAsync()
        {
            return await _context.Reservations.ToListAsync();
        }

        public async Task<Reservation> GetReservationByIdAsync(int resId)
        {
            return await _context.Reservations.SingleOrDefaultAsync(r => r.Id == resId);
        }

        public async Task UpdateReservationAsync(Reservation res)
        {
            _context.Reservations.Update(res);
            await _context.SaveChangesAsync();
        }
    }
}
