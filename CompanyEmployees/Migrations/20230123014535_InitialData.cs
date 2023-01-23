using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CompanyEmployees.Migrations
{
    /// <inheritdoc />
    public partial class InitialData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Companies",
                columns: new[] { "CompanyId", "Address", "Country", "Name" },
                values: new object[,]
                {
                    { new Guid("1eee8241-6630-4102-9391-ade44be8d0b1"), "583 Wall Dr. Gwynn Oak, MD 21207", "USA", "IT_Solutions Ltd" },
                    { new Guid("d2e68687-ecfc-4e95-ba25-c9c328496b3f"), "312 Forest Avenue, BF 923", "USA", "Admin_Solutions Ltd" }
                });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "EmployeeId", "Age", "CompanyId", "Name", "Position" },
                values: new object[,]
                {
                    { new Guid("2323691b-9563-44c4-b29b-8dfec0f6e3ab"), 35, new Guid("d2e68687-ecfc-4e95-ba25-c9c328496b3f"), "Kane Miller", "Administrator" },
                    { new Guid("d0f9f9d3-0b74-400e-8b31-84d2a4f76534"), 30, new Guid("1eee8241-6630-4102-9391-ade44be8d0b1"), "Jana McLeaf", "Software developer" },
                    { new Guid("ea5c1565-632a-4f1d-ac32-c49f2785ae72"), 26, new Guid("d2e68687-ecfc-4e95-ba25-c9c328496b3f"), "Sam Raiden", "Software developer" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "EmployeeId",
                keyValue: new Guid("2323691b-9563-44c4-b29b-8dfec0f6e3ab"));

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "EmployeeId",
                keyValue: new Guid("d0f9f9d3-0b74-400e-8b31-84d2a4f76534"));

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "EmployeeId",
                keyValue: new Guid("ea5c1565-632a-4f1d-ac32-c49f2785ae72"));

            migrationBuilder.DeleteData(
                table: "Companies",
                keyColumn: "CompanyId",
                keyValue: new Guid("1eee8241-6630-4102-9391-ade44be8d0b1"));

            migrationBuilder.DeleteData(
                table: "Companies",
                keyColumn: "CompanyId",
                keyValue: new Guid("d2e68687-ecfc-4e95-ba25-c9c328496b3f"));
        }
    }
}
