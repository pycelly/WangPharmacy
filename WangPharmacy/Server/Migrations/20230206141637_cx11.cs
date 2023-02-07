using Microsoft.EntityFrameworkCore.Migrations;

namespace WangPharmacy.Server.Migrations
{
    public partial class cx11 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 1,
                column: "CustomerAddress",
                value: "1321123");

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 2,
                column: "CustomerAddress",
                value: "1321123");

            migrationBuilder.UpdateData(
                table: "Medicines",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "MedicineDescription", "MedicineName", "MedicinePrice", "MedicineType" },
                values: new object[] { "To g2ain muscle", "protei1n1", 2223.23, "gy1m" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 1,
                column: "CustomerAddress",
                value: null);

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 2,
                column: "CustomerAddress",
                value: null);

            migrationBuilder.UpdateData(
                table: "Medicines",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "MedicineDescription", "MedicineName", "MedicinePrice", "MedicineType" },
                values: new object[] { "To gain muscle", "protein1", 223.22999999999999, "gym" });
        }
    }
}
