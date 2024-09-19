using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using RestaurantBooking.Models;

namespace RestaurantBooking.Data
{
    public class BookingDbContext : IdentityDbContext<User>
    {

        public BookingDbContext(DbContextOptions<BookingDbContext> options) : base(options) { }
        
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Reservation> Reservations { get; set; }
        public DbSet<Table> Tables { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Dish> Dishes { get; set; }


        // add default dishes when db is created, a few tables, an old reservation and a customer
    }
}
