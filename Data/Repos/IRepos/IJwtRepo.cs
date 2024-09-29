using RestaurantBooking.Models;

namespace RestaurantBooking.Data.Repos.IRepos
{
    public interface IJwtRepo
    {
        public string GenerateJwt(User user);
    }
}
