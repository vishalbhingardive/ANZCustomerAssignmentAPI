using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyTraining1121AngularDemo.Migrations
{
    public partial class UsersCustomer : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TenantId",
                table: "CustomerUsers",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreationTime",
                table: "Customers",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<long>(
                name: "CreatorUserId",
                table: "Customers",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "DeleterUserId",
                table: "Customers",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletionTime",
                table: "Customers",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Customers",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "LastModificationTime",
                table: "Customers",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "LastModifierUserId",
                table: "Customers",
                type: "bigint",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_CustomerUsers_TenantId",
                table: "CustomerUsers",
                column: "TenantId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_CustomerUsers_TenantId",
                table: "CustomerUsers");

            migrationBuilder.DropColumn(
                name: "TenantId",
                table: "CustomerUsers");

            migrationBuilder.DropColumn(
                name: "CreationTime",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "CreatorUserId",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "DeleterUserId",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "DeletionTime",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "LastModificationTime",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "LastModifierUserId",
                table: "Customers");
        }
    }
}
