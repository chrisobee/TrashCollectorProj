using Microsoft.EntityFrameworkCore.Migrations;

namespace TrashCollector.Data.Migrations
{
    public partial class AddedRoles : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "26f575f1 - ca97 - 4a58 - b87e - 69fc4907ef81",
                column: "ConcurrencyStamp",
                value: "fdc70a5b-ca37-403b-8dbb-bd26ac6cd085");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "3e1ea929-a517-49d8-87bc-dec994a34e67", "922e69c9-b3aa-4a94-9c46-49c6a8592d4f", "Employee", "EMPLOYEE" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "01c8a6c3-a16b-4bbc-9789-88db637c8778", "181e2423-b1dd-4f35-a731-56869e39b217", "Customer", "CUSTOMER" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "01c8a6c3-a16b-4bbc-9789-88db637c8778");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3e1ea929-a517-49d8-87bc-dec994a34e67");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "26f575f1 - ca97 - 4a58 - b87e - 69fc4907ef81",
                column: "ConcurrencyStamp",
                value: "b78b430a-649f-4df3-836e-db3013106ed7");
        }
    }
}
