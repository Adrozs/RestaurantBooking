using Microsoft.AspNet.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using RestaurantBooking.Models;
using System.Reflection.Emit;

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
        public DbSet<User> Users { get; set; }

        // Add default dishes, customers, tables, reservations when DB is created
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);


            // Default admin
            var hasher = new PasswordHasher<User>();    
            modelBuilder.Entity<User>().HasData(
                new User
                {
                    Id = "34175520-2c0d-4559-b6fd-652e1429f932", 
                    UserName = "admin",
                    NormalizedUserName = "admin",
                    EmailConfirmed = false,
                    PasswordHash = hasher.HashPassword(null, "Admin!123"),
                    SecurityStamp = string.Empty
                });;


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
                    IsAvailable = true,
                    MealType = "Main"
                },
                new Dish
                {
                    Id = 2,
                    Name = "Spaghetti C#rbonara",
                    Description = "Spaghetti tossed in a creamy carbonara sauce with pancetta, topped with fresh black pepper and parmesan.",
                    Price = 15.99m,
                    IsAvailable = true,
                    MealType = "Main"
                },
                new Dish
                {
                    Id = 3,
                    Name = "Boolean Burger",
                    Description = "A plant-based burger with lettuce, tomato, pickles, and vegan aioli, served with sweet potato fries.",
                    Price = 13.99m,
                    IsAvailable = false,
                    MealType = "Main"
                },
                new Dish
                {
                    Id = 4,
                    Name = "Grilled Query Salmon",
                    Description = "Grilled salmon filet with a honey mustard glaze, served with quinoa and steamed broccoli.",
                    Price = 18.99m,
                    IsAvailable = true,
                    MealType = "Main"
                },
                new Dish
                {
                    Id = 5,
                    Name = "Runtime Ribs",
                    Description = "Slow-cooked BBQ ribs served with coleslaw and cornbread, fall-off-the-bone tender.",
                    Price = 22.99m,
                    IsAvailable = false,
                    MealType = "Main"
                },
                new Dish
                {
                    Id = 6,
                    Name = "Fork() Filet",
                    Description = "Grilled filet mignon served with garlic mashed potatoes and steamed vegetables.",
                    Price = 25.99m,
                    IsAvailable = true,
                    MealType = "Main"
                },
                new Dish
                {
                    Id = 7,
                    Name = "Command Line Cod",
                    Description = "Pan-seared cod with lemon butter sauce, served with wild rice and roasted asparagus.",
                    Price = 17.99m,
                    IsAvailable = true,
                    MealType = "Main"
                },
                new Dish
                {
                    Id = 8,
                    Name = "Recursion Ravioli",
                    Description = "Handmade ricotta-filled ravioli in a rich marinara sauce, garnished with fresh basil.",
                    Price = 14.99m,
                    IsAvailable = false,
                    MealType = "Main"
                },
                new Dish
                {
                    Id = 9,
                    Name = "Full Stack Fajitas",
                    Description = "Grilled beef or chicken with sautéed peppers and onions, served with flour tortillas, guacamole, sour cream, and salsa.",
                    Price = 16.99m,
                    IsAvailable = true,
                    MealType = "Main"
                },
                new Dish
                {
                    Id = 10,
                    Name = "Garlic Bread Gateway",
                    Description = "Crispy garlic bread slices toasted with a blend of butter, garlic, and parsley, served with a side of tzatziki.",
                    Price = 6.99m,
                    IsAvailable = true,
                    MealType = "Appetizer"
                },
                new Dish
                {
                    Id = 11,
                    Name = "Toast Skagen Stack",
                    Description = "A Swedish classic with prawns, mayonnaise, dill, and a hint of lemon, served on toasted bread, topped with fish roe.",
                    Price = 9.99m,
                    IsAvailable = true,
                    MealType = "Appetizer"
                },
                new Dish
                {
                    Id = 12,
                    Name = "Bitstream Bruschetta",
                    Description = "Toasted slices of Italian bread topped with a fresh tomato and basil mixture, drizzled with olive oil and balsamic glaze.",
                    Price = 7.99m,
                    IsAvailable = true,
                    MealType = "Appetizer"
                },
                new Dish
                {
                    Id = 13,
                    Name = "Algorithmic Apple Pie",
                    Description = "Classic apple pie with a lattice crust, filled with spiced apples, and served with a scoop of vanilla ice cream.",
                    Price = 7.99m,
                    IsAvailable = true,
                    MealType = "Dessert"
                },
                new Dish
                {
                    Id = 14,
                    Name = "Binary Brownie Bytes",
                    Description = "Rich chocolate brownies served in bite-sized portions, with a side of whipped cream and raspberry coulis.",
                    Price = 5.99m,
                    IsAvailable = true,
                    MealType = "Dessert"
                },
                new Dish
                {
                    Id = 15,
                    Name = "Recursive Raspberry Tart",
                    Description = "A delicate tart shell filled with creamy custard and topped with fresh raspberries, finished with a dusting of powdered sugar.",
                    Price = 14.99m,
                    IsAvailable = true,
                    MealType = "Dessert"
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
