using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace E_commerce.Persistence.Migrations
{
    public partial class cartentity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1L,
                column: "InsertTime",
                value: new DateTime(2023, 8, 1, 20, 35, 2, 718, DateTimeKind.Local).AddTicks(3285));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2L,
                column: "InsertTime",
                value: new DateTime(2023, 8, 1, 20, 35, 2, 719, DateTimeKind.Local).AddTicks(9296));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 3L,
                column: "InsertTime",
                value: new DateTime(2023, 8, 1, 20, 35, 2, 719, DateTimeKind.Local).AddTicks(9436));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
    }
}
