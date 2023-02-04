using Microsoft.EntityFrameworkCore.Migrations;

namespace WangPharmacy.Server.Data.Migrations
{
    public partial class AddedDefaultDataAndUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<double>(
                name: "MedicinePrice",
                table: "Medicines",
                type: "float",
                nullable: false,
                oldClrType: typeof(float),
                oldType: "real");

            migrationBuilder.InsertData(
                table: "Medicines",
                columns: new[] { "Id", "MedicineDescription", "MedicineName", "MedicinePrice", "MedicineType" },
                values: new object[] { 1, "To treat fever", "panadol", 2.23, "general" });

            migrationBuilder.InsertData(
                table: "Medicines",
                columns: new[] { "Id", "MedicineDescription", "MedicineName", "MedicinePrice", "MedicineType" },
                values: new object[] { 2, "To gain muscle", "protein", 223.22999999999999, "gym" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Medicines",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Medicines",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.AlterColumn<float>(
                name: "MedicinePrice",
                table: "Medicines",
                type: "real",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float");
        }
    }
}
