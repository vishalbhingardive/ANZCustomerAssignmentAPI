using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyTraining1121AngularDemo.Migrations
{
    public partial class UpdatedCustomer1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "UserId",
                table: "Customer",
                type: "bigint",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Customer_UserId",
                table: "Customer",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Customer_AbpUsers_UserId",
                table: "Customer",
                column: "UserId",
                principalTable: "AbpUsers",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Customer_AbpUsers_UserId",
                table: "Customer");

            migrationBuilder.DropIndex(
                name: "IX_Customer_UserId",
                table: "Customer");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Customer");
        }
    }
}
