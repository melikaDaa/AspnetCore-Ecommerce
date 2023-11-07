using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace E_commerce.Persistence.Migrations
{
    public partial class addBaseEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "InsertTime",
                table: "Users",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "Users",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsRemoved",
                table: "Users",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "RemoveTime",
                table: "Users",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdateTime",
                table: "Users",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "InsertTime",
                table: "UserInRoles",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<bool>(
                name: "IsRemoved",
                table: "UserInRoles",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "RemoveTime",
                table: "UserInRoles",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdateTime",
                table: "UserInRoles",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "InsertTime",
                table: "Roles",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<bool>(
                name: "IsRemoved",
                table: "Roles",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "RemoveTime",
                table: "Roles",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdateTime",
                table: "Roles",
                type: "datetime2",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1L,
                column: "InsertTime",
                value: new DateTime(2023, 7, 29, 12, 32, 28, 734, DateTimeKind.Local).AddTicks(7778));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2L,
                column: "InsertTime",
                value: new DateTime(2023, 7, 29, 12, 32, 28, 736, DateTimeKind.Local).AddTicks(7102));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 3L,
                column: "InsertTime",
                value: new DateTime(2023, 7, 29, 12, 32, 28, 736, DateTimeKind.Local).AddTicks(7201));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "InsertTime",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "IsRemoved",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "RemoveTime",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "UpdateTime",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "InsertTime",
                table: "UserInRoles");

            migrationBuilder.DropColumn(
                name: "IsRemoved",
                table: "UserInRoles");

            migrationBuilder.DropColumn(
                name: "RemoveTime",
                table: "UserInRoles");

            migrationBuilder.DropColumn(
                name: "UpdateTime",
                table: "UserInRoles");

            migrationBuilder.DropColumn(
                name: "InsertTime",
                table: "Roles");

            migrationBuilder.DropColumn(
                name: "IsRemoved",
                table: "Roles");

            migrationBuilder.DropColumn(
                name: "RemoveTime",
                table: "Roles");

            migrationBuilder.DropColumn(
                name: "UpdateTime",
                table: "Roles");
        }
    }
}
