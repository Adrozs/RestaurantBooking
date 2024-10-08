﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using RestaurantBooking.Data;

#nullable disable

namespace RestaurantBooking.Migrations
{
    [DbContext(typeof(BookingDbContext))]
    [Migration("20240929102821_AddIdentity")]
    partial class AddIdentity
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("RestaurantBooking.Models.Customer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasMaxLength(12)
                        .HasColumnType("nvarchar(12)");

                    b.HasKey("Id");

                    b.ToTable("Customers");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Kalle Kaviár",
                            PhoneNumber = "0701234567"
                        });
                });

            modelBuilder.Entity("RestaurantBooking.Models.Dish", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<bool>("IsAvailable")
                        .HasColumnType("bit");

                    b.Property<string>("MealType")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,4)");

                    b.HasKey("Id");

                    b.ToTable("Dishes");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Description = "Crispy chicken tenders served with three dipping sauces: honey mustard, BBQ, and ranch.",
                            IsAvailable = true,
                            MealType = "Main",
                            Name = "Byte-sized Bites",
                            Price = 12.99m
                        },
                        new
                        {
                            Id = 2,
                            Description = "Spaghetti tossed in a creamy carbonara sauce with pancetta, topped with fresh black pepper and parmesan.",
                            IsAvailable = true,
                            MealType = "Main",
                            Name = "Spaghetti C#rbonara",
                            Price = 15.99m
                        },
                        new
                        {
                            Id = 3,
                            Description = "A plant-based burger with lettuce, tomato, pickles, and vegan aioli, served with sweet potato fries.",
                            IsAvailable = false,
                            MealType = "Main",
                            Name = "Boolean Burger",
                            Price = 13.99m
                        },
                        new
                        {
                            Id = 4,
                            Description = "Grilled salmon filet with a honey mustard glaze, served with quinoa and steamed broccoli.",
                            IsAvailable = true,
                            MealType = "Main",
                            Name = "Grilled Query Salmon",
                            Price = 18.99m
                        },
                        new
                        {
                            Id = 5,
                            Description = "Slow-cooked BBQ ribs served with coleslaw and cornbread, fall-off-the-bone tender.",
                            IsAvailable = false,
                            MealType = "Main",
                            Name = "Runtime Ribs",
                            Price = 22.99m
                        },
                        new
                        {
                            Id = 6,
                            Description = "Grilled filet mignon served with garlic mashed potatoes and steamed vegetables.",
                            IsAvailable = true,
                            MealType = "Main",
                            Name = "Fork() Filet",
                            Price = 25.99m
                        },
                        new
                        {
                            Id = 7,
                            Description = "Pan-seared cod with lemon butter sauce, served with wild rice and roasted asparagus.",
                            IsAvailable = true,
                            MealType = "Main",
                            Name = "Command Line Cod",
                            Price = 17.99m
                        },
                        new
                        {
                            Id = 8,
                            Description = "Handmade ricotta-filled ravioli in a rich marinara sauce, garnished with fresh basil.",
                            IsAvailable = false,
                            MealType = "Main",
                            Name = "Recursion Ravioli",
                            Price = 14.99m
                        },
                        new
                        {
                            Id = 9,
                            Description = "Grilled beef or chicken with sautéed peppers and onions, served with flour tortillas, guacamole, sour cream, and salsa.",
                            IsAvailable = true,
                            MealType = "Main",
                            Name = "Full Stack Fajitas",
                            Price = 16.99m
                        },
                        new
                        {
                            Id = 10,
                            Description = "Crispy garlic bread slices toasted with a blend of butter, garlic, and parsley, served with a side of tzatziki.",
                            IsAvailable = true,
                            MealType = "Appetizer",
                            Name = "Garlic Bread Gateway",
                            Price = 6.99m
                        },
                        new
                        {
                            Id = 11,
                            Description = "A Swedish classic with prawns, mayonnaise, dill, and a hint of lemon, served on toasted bread, topped with fish roe.",
                            IsAvailable = true,
                            MealType = "Appetizer",
                            Name = "Toast Skagen Stack",
                            Price = 9.99m
                        },
                        new
                        {
                            Id = 12,
                            Description = "Toasted slices of Italian bread topped with a fresh tomato and basil mixture, drizzled with olive oil and balsamic glaze.",
                            IsAvailable = true,
                            MealType = "Appetizer",
                            Name = "Bitstream Bruschetta",
                            Price = 7.99m
                        },
                        new
                        {
                            Id = 13,
                            Description = "Classic apple pie with a lattice crust, filled with spiced apples, and served with a scoop of vanilla ice cream.",
                            IsAvailable = true,
                            MealType = "Dessert",
                            Name = "Algorithmic Apple Pie",
                            Price = 7.99m
                        },
                        new
                        {
                            Id = 14,
                            Description = "Rich chocolate brownies served in bite-sized portions, with a side of whipped cream and raspberry coulis.",
                            IsAvailable = true,
                            MealType = "Dessert",
                            Name = "Binary Brownie Bytes",
                            Price = 5.99m
                        },
                        new
                        {
                            Id = 15,
                            Description = "A delicate tart shell filled with creamy custard and topped with fresh raspberries, finished with a dusting of powdered sugar.",
                            IsAvailable = true,
                            MealType = "Dessert",
                            Name = "Recursive Raspberry Tart",
                            Price = 14.99m
                        });
                });

            modelBuilder.Entity("RestaurantBooking.Models.Order", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("DishId")
                        .HasColumnType("int");

                    b.Property<int>("ReservationId")
                        .HasColumnType("int");

                    b.Property<string>("SpecialInstructions")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("DishId");

                    b.HasIndex("ReservationId");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("RestaurantBooking.Models.Reservation", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CustomerId")
                        .HasColumnType("int");

                    b.Property<int>("Guests")
                        .HasColumnType("int");

                    b.Property<int>("ReservationDurationMinutes")
                        .HasColumnType("int");

                    b.Property<DateTime>("ReservationTime")
                        .HasColumnType("datetime2");

                    b.Property<int>("TableId")
                        .HasColumnType("int");

                    b.Property<decimal>("TotalBill")
                        .HasColumnType("decimal(18,4)");

                    b.HasKey("Id");

                    b.HasIndex("CustomerId");

                    b.HasIndex("TableId");

                    b.ToTable("Reservations");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CustomerId = 1,
                            Guests = 2,
                            ReservationDurationMinutes = 0,
                            ReservationTime = new DateTime(2024, 9, 29, 12, 28, 21, 589, DateTimeKind.Local).AddTicks(7080),
                            TableId = 1,
                            TotalBill = 0m
                        });
                });

            modelBuilder.Entity("RestaurantBooking.Models.Table", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime?>("ReservedUntil")
                        .HasColumnType("datetime2");

                    b.Property<int>("Seats")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Tables");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Seats = 2
                        },
                        new
                        {
                            Id = 2,
                            Seats = 4
                        },
                        new
                        {
                            Id = 3,
                            Seats = 6
                        });
                });

            modelBuilder.Entity("RestaurantBooking.Models.User", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers", (string)null);

                    b.HasData(
                        new
                        {
                            Id = "34175520-2c0d-4559-b6fd-652e1429f932",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "07af2b33-3c24-4af8-8756-ad58fd5f312c",
                            EmailConfirmed = false,
                            LockoutEnabled = false,
                            NormalizedUserName = "admin",
                            PasswordHash = "AQAAAAIAAYagAAAAEO/dpzZvZxrxtZkEH0KMXME6fuAUEEMu9vt9Y8yiU2S0Y2KBCEE5G5cWrwWCnFD31Q==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "",
                            TwoFactorEnabled = false,
                            UserName = "admin"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("RestaurantBooking.Models.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("RestaurantBooking.Models.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("RestaurantBooking.Models.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("RestaurantBooking.Models.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("RestaurantBooking.Models.Order", b =>
                {
                    b.HasOne("RestaurantBooking.Models.Dish", "Dish")
                        .WithMany()
                        .HasForeignKey("DishId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("RestaurantBooking.Models.Reservation", "Reservation")
                        .WithMany("Orders")
                        .HasForeignKey("ReservationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Dish");

                    b.Navigation("Reservation");
                });

            modelBuilder.Entity("RestaurantBooking.Models.Reservation", b =>
                {
                    b.HasOne("RestaurantBooking.Models.Customer", "Customer")
                        .WithMany("Reservations")
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("RestaurantBooking.Models.Table", "Table")
                        .WithMany("Reservations")
                        .HasForeignKey("TableId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Customer");

                    b.Navigation("Table");
                });

            modelBuilder.Entity("RestaurantBooking.Models.Customer", b =>
                {
                    b.Navigation("Reservations");
                });

            modelBuilder.Entity("RestaurantBooking.Models.Reservation", b =>
                {
                    b.Navigation("Orders");
                });

            modelBuilder.Entity("RestaurantBooking.Models.Table", b =>
                {
                    b.Navigation("Reservations");
                });
#pragma warning restore 612, 618
        }
    }
}
