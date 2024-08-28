using Microsoft.EntityFrameworkCore;
using RestaurantBooking.Data.Repos.IRepos;
using RestaurantBooking.Models;

namespace RestaurantBooking.Data.Repos
{
    public class DishRepo : IDishRepo
    {
        private readonly BookingDbContext _context;

        public DishRepo(BookingDbContext context)
        {
            _context = context;
        }

        public async Task CreateDishAsync(Dish dish)
        {
            _context.Dishes.Add(dish);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteDishAsync(Dish dish)
        {
            _context.Dishes.Remove(dish);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Dish>> GetAllDishesAsync()
        {
            return await _context.Dishes.ToListAsync();
        }

        public async Task<IEnumerable<Dish>> GetAvailableDishesAsync()
        {
            return await _context.Dishes.Where(d => d.IsAvailable).ToListAsync();
        }

        public async Task<Dish> GetDishByIdAsync(int dishId)
        {
            return await _context.Dishes.SingleOrDefaultAsync(d => d.Id == dishId);
        }

        public async Task UpdateDishAsync(Dish dish)
        {
            _context.Dishes.Update(dish);
            await _context.SaveChangesAsync();
        }
    }
}
