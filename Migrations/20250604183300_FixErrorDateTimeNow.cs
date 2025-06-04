using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace efCourse.Migrations
{
    /// <inheritdoc />
    public partial class FixErrorDateTimeNow : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Task",
                keyColumn: "TaskId",
                keyValue: new Guid("4ab33fe8-1ee4-48bb-8a98-c82989ec2333"),
                columns: new[] { "CreationDate", "Deadline" },
                values: new object[] { new DateTime(2025, 6, 4, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2025, 6, 11, 0, 0, 0, 0, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Task",
                keyColumn: "TaskId",
                keyValue: new Guid("4ab33fe8-1ee4-48bb-8a98-c82989ec2334"),
                columns: new[] { "CreationDate", "Deadline" },
                values: new object[] { new DateTime(2025, 6, 4, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2025, 6, 7, 0, 0, 0, 0, DateTimeKind.Local) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
    }
}
