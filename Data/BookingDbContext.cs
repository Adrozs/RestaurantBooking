using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using RestaurantBooking.Models;
using System.Reflection.Emit;

namespace RestaurantBooking.Data
{
    public class BookingDbContext : DbContext
    {
        public BookingDbContext(DbContextOptions<BookingDbContext> options) : base(options) { }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Reservation> Reservations { get; set; }
        public DbSet<Table> Tables { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Dish> Dishes { get; set; }

        // Add default dishes, customers, tables, reservations when DB is created
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Default customer
            modelBuilder.Entity<Customer>().HasData(
                new Customer
                {
                    Id = 1,
                    Name = "Kalle Kaviár",
                    PhoneNumber = "0701234567"
                }
            );

            // Default tables
            modelBuilder.Entity<Table>().HasData(
                new Table
                {
                    Id = 1,
                    Seats = 2
                },
                new Table
                {
                    Id = 2,
                    Seats = 4
                },
                new Table
                {
                    Id = 3,
                    Seats = 6
                }
            );

            // Default dishes
            modelBuilder.Entity<Dish>().HasData(
                new Dish
                {
                    Id = 1,
                    Name = "Byte-sized Bites",
                    Description = "Crispy chicken tenders served with three dipping sauces: honey mustard, BBQ, and ranch.",
                    Price = 12.99m,
                    IsAvailable = true
                },
                new Dish
                {
                    Id = 2,
                    Name = "Spaghetti C#rbonara",
                    Description = "Spaghetti tossed in a creamy carbonara sauce with pancetta, topped with fresh black pepper and parmesan.",
                    Price = 15.99m,
                    IsAvailable = true
                },
                new Dish
                {
                    Id = 3,
                    Name = "Boolean Burger",
                    Description = "A plant-based burger with lettuce, tomato, pickles, and vegan aioli, served with sweet potato fries.",
                    Price = 13.99m,
                    IsAvailable = false
                },
                new Dish
                {
                    Id = 4,
                    Name = "SQL-icious Salmon",
                    Description = "Grilled salmon filet with a honey mustard glaze, served with quinoa and steamed broccoli.",
                    Price = 18.99m,
                    IsAvailable = true
                },
                new Dish
                {
                    Id = 5,
                    Name = "Runtime Ribs",
                    Description = "Slow-cooked BBQ ribs served with coleslaw and cornbread, fall-off-the-bone tender.",
                    Price = 22.99m,
                    IsAvailable = false
                },
                new Dish
                {
                    Id = 6,
                    Name = "Fork() Filet",
                    Description = "Grilled filet mignon served with garlic mashed potatoes and steamed vegetables.",
                    Price = 25.99m,
                    IsAvailable = true
                },
                new Dish
                {
                    Id = 7,
                    Name = "Command Line Cod",
                    Description = "Pan-seared cod with lemon butter sauce, served with wild rice and roasted asparagus.",
                    Price = 17.99m,
                    IsAvailable = true
                },
                new Dish
                {
                    Id = 8,
                    Name = "Recursion Ravioli",
                    Description = "Handmade ricotta-filled ravioli in a rich marinara sauce, garnished with fresh basil.",
                    Price = 14.99m,
                    IsAvailable = false
                },
                new Dish
                {
                    Id = 9,
                    Name = "Full Stack Fajitas",
                    Description = "Grilled beef or chicken with sautéed peppers and onions, served with flour tortillas, guacamole, sour cream, and salsa.",
                    Price = 16.99m,
                    IsAvailable = true
                }
            );

            // Default reservation 
            modelBuilder.Entity<Reservation>().HasData(
                new Reservation
                {
                    Id = 1,
                    CustomerId = 1,  
                    TableId = 1,     
                    Guests = 2,
                    ReservationTime = DateTime.Now
                }
            );
        }
    }
}
