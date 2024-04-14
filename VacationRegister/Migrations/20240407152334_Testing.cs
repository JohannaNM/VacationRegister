using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace VacationRegister.Migrations
{
    /// <inheritdoc />
    public partial class Testing : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Departments",
                columns: ["DepartmentId", "DepartmentName"],
                values: new object[,]
                {
                    { 1, "Economics" },
                    { 2, "Administration" }
                });

            migrationBuilder.InsertData(
                table: "LeaveTypes",
                columns: ["LeaveTypeId", "LeaveDescr", "TypeofLeave"],
                values: new object[,]
                {
                    { 1, "Ordinary vacation", "Holiday" },
                    { 2, "Time off to take care of children", "Child-care" },
                    { 3, "For things like hospital appointments", "Personal" },
                    { 4, "If you are to sick to work today", "Sick" }
                });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: ["EmpId", "BirthDate", "DepartmentId", "FirstName", "LastName"],
                values: [1, new DateTime(2001, 7, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Andreas", "Fors"]);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "DepartmentId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "EmpId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "LeaveTypes",
                keyColumn: "LeaveTypeId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "LeaveTypes",
                keyColumn: "LeaveTypeId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "LeaveTypes",
                keyColumn: "LeaveTypeId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "LeaveTypes",
                keyColumn: "LeaveTypeId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "DepartmentId",
                keyValue: 1);
        }
    }
}
