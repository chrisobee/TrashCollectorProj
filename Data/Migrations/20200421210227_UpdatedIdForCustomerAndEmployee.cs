using Microsoft.EntityFrameworkCore.Migrations;

namespace TrashCollector.Data.Migrations
{
    public partial class UpdatedIdForCustomerAndEmployee : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "01c8a6c3-a16b-4bbc-9789-88db637c8778",
                column: "ConcurrencyStamp",
                value: "e17753b0-5d9d-4cd1-acec-045dddf4c929");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "26f575f1 - ca97 - 4a58 - b87e - 69fc4907ef81",
                column: "ConcurrencyStamp",
                value: "c41fe56f-c882-4398-9993-011b23e36ec8");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3e1ea929-a517-49d8-87bc-dec994a34e67",
                column: "ConcurrencyStamp",
                value: "bcef994d-0d48-4d74-a34b-47f9cc61cf99");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "01c8a6c3-a16b-4bbc-9789-88db637c8778",
                column: "ConcurrencyStamp",
                value: "181e2423-b1dd-4f35-a731-56869e39b217");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "26f575f1 - ca97 - 4a58 - b87e - 69fc4907ef81",
                column: "ConcurrencyStamp",
                value: "fdc70a5b-ca37-403b-8dbb-bd26ac6cd085");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3e1ea929-a517-49d8-87bc-dec994a34e67",
                column: "ConcurrencyStamp",
                value: "922e69c9-b3aa-4a94-9c46-49c6a8592d4f");
        }
    }
}
