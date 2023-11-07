using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace E_commerce.Persistence.Migrations
{
    public partial class editorder : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1L,
                column: "InsertTime",
                value: new DateTime(2023, 8, 5, 20, 31, 41, 515, DateTimeKind.Local).AddTicks(889));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2L,
                column: "InsertTime",
                value: new DateTime(2023, 8, 5, 20, 31, 41, 516, DateTimeKind.Local).AddTicks(6226));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 3L,
                column: "InsertTime",
                value: new DateTime(2023, 8, 5, 20, 31, 41, 516, DateTimeKind.Local).AddTicks(6325));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1L,
                column: "InsertTime",
                value: new DateTime(2023, 8, 5, 20, 18, 10, 247, DateTimeKind.Local).AddTicks(2844));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2L,
                column: "InsertTime",
                value: new DateTime(2023, 8, 5, 20, 18, 10, 249, DateTimeKind.Local).AddTicks(241));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 3L,
                column: "InsertTime",
                value: new DateTime(2023, 8, 5, 20, 18, 10, 249, DateTimeKind.Local).AddTicks(353));
        }
    }
}
