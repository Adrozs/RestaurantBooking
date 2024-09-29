using RestaurantBooking.Models.DTOs;

namespace RestaurantBooking.Services.IServices
{
    public interface IUserService
    {
        public Task<string> LoginAsync(UserCredsDto userCredsDto);
        public Task<bool> CreateAccountAsync(UserCredsDto userCredsDto);
        
    }
}
