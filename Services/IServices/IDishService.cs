using RestaurantBooking.Models.DTOs.DishDTOs;

namespace RestaurantBooking.Services.IServices
{
    public interface IDishService
    {
        public Task CreateDishAsync(CreateDishDTO dish);
        public Task<IEnumerable<DishDTO>> GetAllDishesAsync();
        public Task<IEnumerable<DishDTO>> GetAvailableDishesAsync();
        public Task<DishDTO> GetDishByIdAsync(int dishId);
        public Task UpdateDishAsync(DishDTO dish);
        public Task DeleteDishAsync(int dishId);
    }
}
