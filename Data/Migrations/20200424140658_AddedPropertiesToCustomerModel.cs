using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TrashCollector.Data.Migrations
{
    public partial class AddedPropertiesToCustomerModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "OneTimePickup",
                table: "Customers",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AddColumn<DateTime>(
                name: "TempEnd",
                table: "Customers",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "TempStart",
                table: "Customers",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "01c8a6c3-a16b-4bbc-9789-88db637c8778",
                column: "ConcurrencyStamp",
                value: "7caa326e-8445-40a8-b7f6-264bb7a037c7");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3e1ea929-a517-49d8-87bc-dec994a34e67",
                column: "ConcurrencyStamp",
                value: "3801e675-1fa6-4261-b2ea-d6788215284c");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TempEnd",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "TempStart",
                table: "Customers");

            migrationBuilder.AlterColumn<DateTime>(
                name: "OneTimePickup",
                table: "Customers",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "01c8a6c3-a16b-4bbc-9789-88db637c8778",
                column: "ConcurrencyStamp",
                value: "3248e2f0-621f-475f-a070-b65faa4b6c93");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3e1ea929-a517-49d8-87bc-dec994a34e67",
                column: "ConcurrencyStamp",
                value: "85fa522c-2bfe-46c6-bce7-12ebb875c32a");
        }
    }
}
