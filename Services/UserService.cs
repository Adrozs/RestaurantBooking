using RestaurantBooking.Data.Repos.IRepos;
using RestaurantBooking.Models;
using RestaurantBooking.Models.DTOs;
using RestaurantBooking.Models.ResultObjects;
using RestaurantBooking.Services.IServices;

namespace RestaurantBooking.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepo _userRepo;
        private readonly IJwtRepo _jwtRepo;

        public UserService(IUserRepo userRepo, IJwtRepo jwtRepo)
        {
            _userRepo = userRepo;
            _jwtRepo = jwtRepo;
        }

        public async Task<bool> CreateAccountAsync(UserCredsDto userCredsDto)
        {
            try
            {
                return await _userRepo.CreateAdminAsync(userCredsDto.Username, userCredsDto.Password);
            }
            catch (Exception ex)
            {
                // Throw error up to controller because I'm too short on time to make better error handling
                throw ex;
            }
            
        }

        public async Task<string> LoginAsync(UserCredsDto userCredsDto)
        {
            try
            {
                // Get success or not and the User object if successful to use for jwt creation
                LoginResult loginResult = await _userRepo.LoginAsync(userCredsDto.Username, userCredsDto.Password);
                if (!loginResult.Success)
                    throw new Exception("Somethning went wrong trying to login.");

                return _jwtRepo.GenerateJwt(loginResult.User);

            }
            catch (Exception ex)
            {
                // Throw error up to controller because I'm too short on time to make better error handling
                throw ex; 
            }
        }
    }
}
