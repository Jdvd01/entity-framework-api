using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace efCourse.Migrations
{
    /// <inheritdoc />
    public partial class RequiredFields : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Task",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Category",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.UpdateData(
                table: "Task",
                keyColumn: "TaskId",
                keyValue: new Guid("4ab33fe8-1ee4-48bb-8a98-c82989ec2333"),
                columns: new[] { "CreationDate", "Deadline" },
                values: new object[] { new DateTime(2025, 6, 4, 14, 27, 8, 538, DateTimeKind.Local).AddTicks(830), new DateTime(2025, 6, 11, 14, 27, 8, 539, DateTimeKind.Local).AddTicks(5418) });

            migrationBuilder.UpdateData(
                table: "Task",
                keyColumn: "TaskId",
                keyValue: new Guid("4ab33fe8-1ee4-48bb-8a98-c82989ec2334"),
                columns: new[] { "CreationDate", "Deadline" },
                values: new object[] { new DateTime(2025, 6, 4, 14, 27, 8, 539, DateTimeKind.Local).AddTicks(5879), new DateTime(2025, 6, 7, 14, 27, 8, 539, DateTimeKind.Local).AddTicks(5882) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Task",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Category",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "Task",
                keyColumn: "TaskId",
                keyValue: new Guid("4ab33fe8-1ee4-48bb-8a98-c82989ec2333"),
                columns: new[] { "CreationDate", "Deadline" },
                values: new object[] { new DateTime(2025, 6, 4, 14, 22, 48, 925, DateTimeKind.Local).AddTicks(1443), new DateTime(2025, 6, 11, 14, 22, 48, 926, DateTimeKind.Local).AddTicks(4946) });

            migrationBuilder.UpdateData(
                table: "Task",
                keyColumn: "TaskId",
                keyValue: new Guid("4ab33fe8-1ee4-48bb-8a98-c82989ec2334"),
                columns: new[] { "CreationDate", "Deadline" },
                values: new object[] { new DateTime(2025, 6, 4, 14, 22, 48, 926, DateTimeKind.Local).AddTicks(5415), new DateTime(2025, 6, 7, 14, 22, 48, 926, DateTimeKind.Local).AddTicks(5418) });
        }
    }
}
