using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SeidoDemoDb.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Necklaces",
                columns: table => new
                {
                    CustomerID = table.Column<Guid>(type: "TEXT", nullable: false),
                    Comment = table.Column<string>(type: "nvarchar (200)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.CustomerID);
                });

            migrationBuilder.CreateTable(
                name: "Pearl",
                columns: table => new
                {
                    OrderID = table.Column<Guid>(type: "TEXT", nullable: false),
                    CustomerID = table.Column<Guid>(type: "TEXT", nullable: false),
                    Comment = table.Column<string>(type: "nvarchar (200)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.OrderID);
                    table.ForeignKey(
                        name: "FK_Orders_Customers_CustomerID",
                        column: x => x.CustomerID,
                        principalTable: "Necklaces",
                        principalColumn: "NecklaceID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Orders_CustomerID",
                table: "Pearl",
                column: "NecklaceID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Pearl");

            migrationBuilder.DropTable(
                name: "Necklaces");
        }
    }
}
