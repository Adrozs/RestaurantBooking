using RestaurantBooking.Models.ResultObjects;

namespace RestaurantBooking.Data.Repos.IRepos
{
    public interface IUserRepo
    {
        public Task<LoginResult> LoginAsync(string username, string password);
        public Task<bool> CreateAdminAsync(string username, string password);
    }
}
