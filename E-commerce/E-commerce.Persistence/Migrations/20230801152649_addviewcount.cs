using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace E_commerce.Persistence.Migrations
{
    public partial class addviewcount : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ViewCount",
                table: "Products",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1L,
                column: "InsertTime",
                value: new DateTime(2023, 8, 1, 18, 56, 49, 303, DateTimeKind.Local).AddTicks(1230));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2L,
                column: "InsertTime",
                value: new DateTime(2023, 8, 1, 18, 56, 49, 304, DateTimeKind.Local).AddTicks(6658));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 3L,
                column: "InsertTime",
                value: new DateTime(2023, 8, 1, 18, 56, 49, 304, DateTimeKind.Local).AddTicks(6897));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ViewCount",
                table: "Products");

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1L,
                column: "InsertTime",
                value: new DateTime(2023, 7, 29, 22, 3, 47, 840, DateTimeKind.Local).AddTicks(5109));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2L,
                column: "InsertTime",
                value: new DateTime(2023, 7, 29, 22, 3, 47, 842, DateTimeKind.Local).AddTicks(950));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 3L,
                column: "InsertTime",
                value: new DateTime(2023, 7, 29, 22, 3, 47, 842, DateTimeKind.Local).AddTicks(1041));
        }
    }
}
