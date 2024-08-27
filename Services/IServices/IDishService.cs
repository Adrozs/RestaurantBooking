using RestaurantBooking.Models;
using RestaurantBooking.Models.DTOs.DishDTOs;

namespace RestaurantBooking.Services.IServices
{
    public interface IDishService
    {
        public Task CreateDishAsync(DishNoIdDTO dish);
        public Task<IEnumerable<DishDTO>> GetAllDishesAsync();
        public Task<DishDTO> GetDishByIdAsync(int dishId);
        public Task UpdateDishAsync(DishDTO dish);
        public Task DeleteDishAsync(int dishId);
    }
}
