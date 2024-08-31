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
            return await _context.Reservations
                .Include(r => r.Customer)
                .ToListAsync();
        }

        public async Task<IEnumerable<Reservation>> GetActiveReservationsAsync()
        {
            return await _context.Reservations
                .Include(r => r.Customer)
                .Where(r => r.ReservationTime >= DateTime.Today)
                .ToListAsync();
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
        
        public async Task<bool> IsTableAvailableAsync(int tableId, DateTime reqResTime, int reqResDurationMinutes)
        {
            // Calculate when requested reservation is supposed to end
            DateTime reqResEndTime = reqResTime.AddMinutes(reqResDurationMinutes);

            // Checks if there's an overlapping reservation for this table
            bool isConflictingRes = await _context.Reservations
                .AnyAsync(r => r.TableId == tableId &&
                reqResTime < r.ReservationTime.AddMinutes(r.ReservationDurationMinutes) &&
                reqResEndTime > r.ReservationTime);

            // Since isConflictingRes equals to true if conflicting we have to return the opposite. As if res is overlapping it table is not available
            return !isConflictingRes;
        }

        public async Task<Reservation> GetReservationAndOrderedDishesByIdAsync(int resId)
        {
            return await _context.Reservations
                .Include(r => r.Customer)
                .Include(r => r.Orders)
                .ThenInclude(o => o.Dish)
                .SingleOrDefaultAsync(r => r.Id == resId);
        }
    }
}
