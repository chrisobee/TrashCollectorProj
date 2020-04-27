using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TrashCollector.Data.Migrations
{
    public partial class AddedTrashPickupPropertyToCustomers : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "PickupTime",
                table: "Customers",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "TrashPickedUp",
                table: "Customers",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "01c8a6c3-a16b-4bbc-9789-88db637c8778",
                column: "ConcurrencyStamp",
                value: "7c8ec48e-646f-43d3-8924-9ab80a3bdf1d");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3e1ea929-a517-49d8-87bc-dec994a34e67",
                column: "ConcurrencyStamp",
                value: "480ab93e-c2c5-4c71-b513-a7023f520149");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PickupTime",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "TrashPickedUp",
                table: "Customers");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "01c8a6c3-a16b-4bbc-9789-88db637c8778",
                column: "ConcurrencyStamp",
                value: "2491f3fb-bf7d-4b6e-9100-856c8f027815");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3e1ea929-a517-49d8-87bc-dec994a34e67",
                column: "ConcurrencyStamp",
                value: "eeafbf29-b84f-4e56-a0c5-f69a31ff9200");
        }
    }
}
