using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Qira.EF.Migrations
{
    public partial class Int : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Invoices",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Amount = table.Column<double>(type: "float", nullable: false),
                    ProcessingStatus = table.Column<int>(type: "int", nullable: false),
                    PaymentMethod = table.Column<int>(type: "int", nullable: false),
                    CreatedDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDataTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Invoices", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Invoices",
                columns: new[] { "Id", "Amount", "CreatedDateTime", "ModifiedDataTime", "PaymentMethod", "ProcessingStatus" },
                values: new object[,]
                {
                    { 1, 100.0, new DateTime(2022, 11, 13, 21, 45, 24, 282, DateTimeKind.Utc).AddTicks(6411), null, 1, 1 },
                    { 3, 25.899999999999999, new DateTime(2022, 11, 14, 21, 45, 24, 282, DateTimeKind.Utc).AddTicks(6420), null, 3, 1 },
                    { 14, 50.049999999999997, new DateTime(2022, 11, 15, 23, 45, 24, 282, DateTimeKind.Utc).AddTicks(6428), null, 1, 3 },
                    { 25, 10.5, new DateTime(2022, 11, 13, 21, 45, 24, 282, DateTimeKind.Utc).AddTicks(6419), null, 2, 2 },
                    { 315, 864.5, new DateTime(2022, 11, 8, 21, 45, 24, 282, DateTimeKind.Utc).AddTicks(6430), null, 1, 1 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Invoices");
        }
    }
}
