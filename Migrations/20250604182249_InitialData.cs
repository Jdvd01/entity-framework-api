using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace efCourse.Migrations
{
    /// <inheritdoc />
    public partial class InitialData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Category",
                columns: new[] { "CategoryId", "Description", "Name", "WorkLoad" },
                values: new object[,]
                {
                    { new Guid("4ab33fe8-1ee4-48bb-8a98-c82989ec2745"), "Tasks related to work", "Work", 20 },
                    { new Guid("4ab33fe8-1ee4-48bb-8a98-c82989ec2746"), "Tasks related to personal life", "Personal", 50 }
                });

            migrationBuilder.InsertData(
                table: "Task",
                columns: new[] { "TaskId", "CategoryId", "CreationDate", "Deadline", "Description", "TaskPriority", "Title" },
                values: new object[,]
                {
                    { new Guid("4ab33fe8-1ee4-48bb-8a98-c82989ec2333"), new Guid("4ab33fe8-1ee4-48bb-8a98-c82989ec2745"), new DateTime(2025, 6, 4, 14, 22, 48, 925, DateTimeKind.Local).AddTicks(1443), new DateTime(2025, 6, 11, 14, 22, 48, 926, DateTimeKind.Local).AddTicks(4946), "Implement the landing page for the new product", 2, "Develop new feature" },
                    { new Guid("4ab33fe8-1ee4-48bb-8a98-c82989ec2334"), new Guid("4ab33fe8-1ee4-48bb-8a98-c82989ec2746"), new DateTime(2025, 6, 4, 14, 22, 48, 926, DateTimeKind.Local).AddTicks(5415), new DateTime(2025, 6, 7, 14, 22, 48, 926, DateTimeKind.Local).AddTicks(5418), "Buy groceries for the week", 1, "Shopping" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Task",
                keyColumn: "TaskId",
                keyValue: new Guid("4ab33fe8-1ee4-48bb-8a98-c82989ec2333"));

            migrationBuilder.DeleteData(
                table: "Task",
                keyColumn: "TaskId",
                keyValue: new Guid("4ab33fe8-1ee4-48bb-8a98-c82989ec2334"));

            migrationBuilder.DeleteData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: new Guid("4ab33fe8-1ee4-48bb-8a98-c82989ec2745"));

            migrationBuilder.DeleteData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: new Guid("4ab33fe8-1ee4-48bb-8a98-c82989ec2746"));
        }
    }
}
