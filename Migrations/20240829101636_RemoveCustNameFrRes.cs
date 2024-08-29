using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RestaurantBooking.Migrations
{
    /// <inheritdoc />
    public partial class RemoveCustNameFrRes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OrderOLD");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "OrderOLD",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ReservationId = table.Column<int>(type: "int", nullable: false),
                    CustomerId = table.Column<int>(type: "int", nullable: true),
                    TotalBill = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderOLD", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrderOLD_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_OrderOLD_Reservations_ReservationId",
                        column: x => x.ReservationId,
                        principalTable: "Reservations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_OrderOLD_CustomerId",
                table: "OrderOLD",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderOLD_ReservationId",
                table: "OrderOLD",
                column: "ReservationId");
        }
    }
}
