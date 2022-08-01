using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyTraining1121AngularDemo.Migrations
{
    public partial class CustomerUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CustomerUsers",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TotalAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CustomerId = table.Column<long>(type: "bigint", nullable: true),
                    UserId = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomerUsers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CustomerUsers_AbpUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AbpUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_CustomerUsers_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_CustomerUsers_CustomerId",
                table: "CustomerUsers",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_CustomerUsers_UserId",
                table: "CustomerUsers",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CustomerUsers");
        }
    }
}
