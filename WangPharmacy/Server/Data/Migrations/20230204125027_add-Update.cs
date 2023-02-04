using Microsoft.EntityFrameworkCore.Migrations;

namespace WangPharmacy.Server.Data.Migrations
{
    public partial class addUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "OrderItemId",
                table: "PrescriptionItems",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_PrescriptionItems_OrderItemId",
                table: "PrescriptionItems",
                column: "OrderItemId");

            migrationBuilder.AddForeignKey(
                name: "FK_PrescriptionItems_OrderItems_OrderItemId",
                table: "PrescriptionItems",
                column: "OrderItemId",
                principalTable: "OrderItems",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PrescriptionItems_OrderItems_OrderItemId",
                table: "PrescriptionItems");

            migrationBuilder.DropIndex(
                name: "IX_PrescriptionItems_OrderItemId",
                table: "PrescriptionItems");

            migrationBuilder.DropColumn(
                name: "OrderItemId",
                table: "PrescriptionItems");
        }
    }
}
