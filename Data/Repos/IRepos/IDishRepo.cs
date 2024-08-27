using RestaurantBooking.Models;

namespace RestaurantBooking.Data.Repos.IRepos
{
    public interface IDishRepo
    {
        public Task CreateDishAsync(Dish dish);
        public Task<IEnumerable<Dish>> GetAllDishesAsync();
        public Task<Dish> GetDishByIdAsync(int dishId);
        public Task UpdateDishAsync(Dish dish);
        public Task DeleteDishAsync(Dish dish);
    }
}
