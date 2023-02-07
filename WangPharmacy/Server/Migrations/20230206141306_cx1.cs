using Microsoft.EntityFrameworkCore.Migrations;

namespace WangPharmacy.Server.Migrations
{
    public partial class cx1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Medicines",
                columns: new[] { "Id", "MedicineDescription", "MedicineName", "MedicinePrice", "MedicineType" },
                values: new object[] { 4, "To gain muscle", "protein1", 223.22999999999999, "gym" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Medicines",
                keyColumn: "Id",
                keyValue: 4);
        }
    }
}
