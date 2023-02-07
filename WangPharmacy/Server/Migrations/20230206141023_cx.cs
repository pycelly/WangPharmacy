using Microsoft.EntityFrameworkCore.Migrations;

namespace WangPharmacy.Server.Migrations
{
    public partial class cx : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "Id", "CustomerAddress", "CustomerContact", "CustomerDOB", "CustomerEmail", "CustomerGender", "CustomerName" },
                values: new object[] { 1, null, "1234123213", "123/123/123", "123@123.com", "male", "Wpy" });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "Id", "CustomerAddress", "CustomerContact", "CustomerDOB", "CustomerEmail", "CustomerGender", "CustomerName" },
                values: new object[] { 2, null, "12341123213", "1213/123/123", "123@123.com1", "1male", "Wpy1" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 2);
        }
    }
}
