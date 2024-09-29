
using Microsoft.AspNetCore.Identity;
using RestaurantBooking.Data.Repos.IRepos;
using RestaurantBooking.Models;
using RestaurantBooking.Models.ResultObjects;

namespace RestaurantBooking.Data.Repos
{
    public class UserRepo : IUserRepo
    {
        private readonly BookingDbContext _context;
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;

        public UserRepo(BookingDbContext context, UserManager<User> userManager, SignInManager<User> signInManager)
        {
            _context = context;
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public async Task<bool> CreateAdminAsync(string username, string password)
        {
            User user = new User
            {
                UserName = username
            };

            var result = await _userManager.CreateAsync(user, password);

            if (!result.Succeeded)
                return false;

            return true;
        }

        public async Task<LoginResult> LoginAsync(string username, string password)
        {
            User? user = await _userManager.FindByNameAsync(username);
            if (user == null)
                return new LoginResult { Success = false, ErrorMessage = "User not found." };

            var result = await _signInManager.PasswordSignInAsync(username, password, isPersistent: false, lockoutOnFailure: false);

            if (!result.Succeeded)
                return new LoginResult { Success = false, ErrorMessage = "Login credentials do not match" };

            return new LoginResult { Success = true, User = user };
        }
    }
}
