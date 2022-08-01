using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyTraining1121AngularDemo.Migrations
{
    public partial class UsersCustomer2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_CustomerUsers_TenantId",
                table: "CustomerUsers");

            migrationBuilder.DropColumn(
                name: "TenantId",
                table: "CustomerUsers");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreationTime",
                table: "CustomerUsers",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<long>(
                name: "CreatorUserId",
                table: "CustomerUsers",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "DeleterUserId",
                table: "CustomerUsers",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletionTime",
                table: "CustomerUsers",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "CustomerUsers",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "LastModificationTime",
                table: "CustomerUsers",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "LastModifierUserId",
                table: "CustomerUsers",
                type: "bigint",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreationTime",
                table: "CustomerUsers");

            migrationBuilder.DropColumn(
                name: "CreatorUserId",
                table: "CustomerUsers");

            migrationBuilder.DropColumn(
                name: "DeleterUserId",
                table: "CustomerUsers");

            migrationBuilder.DropColumn(
                name: "DeletionTime",
                table: "CustomerUsers");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "CustomerUsers");

            migrationBuilder.DropColumn(
                name: "LastModificationTime",
                table: "CustomerUsers");

            migrationBuilder.DropColumn(
                name: "LastModifierUserId",
                table: "CustomerUsers");

            migrationBuilder.AddColumn<int>(
                name: "TenantId",
                table: "CustomerUsers",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_CustomerUsers_TenantId",
                table: "CustomerUsers",
                column: "TenantId");
        }
    }
}
