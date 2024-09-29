using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace RestaurantBooking.Migrations
{
    /// <inheritdoc />
    public partial class AddDishCategory : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "MealType",
                table: "Dishes",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "Dishes",
                keyColumn: "Id",
                keyValue: 1,
                column: "MealType",
                value: "Main");

            migrationBuilder.UpdateData(
                table: "Dishes",
                keyColumn: "Id",
                keyValue: 2,
                column: "MealType",
                value: "Main");

            migrationBuilder.UpdateData(
                table: "Dishes",
                keyColumn: "Id",
                keyValue: 3,
                column: "MealType",
                value: "Main");

            migrationBuilder.UpdateData(
                table: "Dishes",
                keyColumn: "Id",
                keyValue: 4,
                column: "MealType",
                value: "Main");

            migrationBuilder.UpdateData(
                table: "Dishes",
                keyColumn: "Id",
                keyValue: 5,
                column: "MealType",
                value: "Main");

            migrationBuilder.UpdateData(
                table: "Dishes",
                keyColumn: "Id",
                keyValue: 6,
                column: "MealType",
                value: "Main");

            migrationBuilder.UpdateData(
                table: "Dishes",
                keyColumn: "Id",
                keyValue: 7,
                column: "MealType",
                value: "Main");

            migrationBuilder.UpdateData(
                table: "Dishes",
                keyColumn: "Id",
                keyValue: 8,
                column: "MealType",
                value: "Main");

            migrationBuilder.UpdateData(
                table: "Dishes",
                keyColumn: "Id",
                keyValue: 9,
                column: "MealType",
                value: "Main");

            migrationBuilder.InsertData(
                table: "Dishes",
                columns: new[] { "Id", "Description", "IsAvailable", "MealType", "Name", "Price" },
                values: new object[,]
                {
                    { 10, "Crispy garlic bread slices toasted with a blend of butter, garlic, and parsley, served with a side of tzatziki.", true, "Appetizer", "Garlic Bread Protocol", 6.99m },
                    { 11, "A Swedish classic with prawns, mayonnaise, dill, and a hint of lemon, served on toasted bread, topped with fish roe.", true, "Appetizer", "Toast Skagen Stack", 9.99m },
                    { 12, "Toasted slices of Italian bread topped with a fresh tomato and basil mixture, drizzled with olive oil and balsamic glaze.", true, "Appetizer", "Bruschetta Bitstream", 7.99m },
                    { 13, "Classic apple pie with a lattice crust, filled with spiced apples, and served with a scoop of vanilla ice cream.", true, "Dessert", "Algorithmic Apple Pie", 7.99m },
                    { 14, "Rich chocolate brownies served in bite-sized portions, with a side of whipped cream and raspberry coulis.", true, "Dessert", "Binary Brownie Bytes", 5.99m },
                    { 15, "A delicate tart shell filled with creamy custard and topped with fresh raspberries, finished with a dusting of powdered sugar.", true, "Dessert", "Recursive Raspberry Tart", 14.99m }
                });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "Id",
                keyValue: 1,
                column: "ReservationTime",
                value: new DateTime(2024, 9, 27, 13, 5, 3, 472, DateTimeKind.Local).AddTicks(672));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Dishes",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Dishes",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Dishes",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Dishes",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Dishes",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Dishes",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DropColumn(
                name: "MealType",
                table: "Dishes");

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "Id",
                keyValue: 1,
                column: "ReservationTime",
                value: new DateTime(2024, 9, 25, 13, 53, 21, 949, DateTimeKind.Local).AddTicks(1685));
        }
    }
}
