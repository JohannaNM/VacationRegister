using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace VacationRegister.Migrations
{
    /// <inheritdoc />
    public partial class SeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Departments",
                columns: new[] { "DepartmentId", "DepartmentName" },
                values: new object[,]
                {
                    { 1, "Economics" },
                    { 2, "Administration" },
                    { 3, "Development" },
                    { 4, "Sales" }
                });

            migrationBuilder.InsertData(
                table: "LeaveTypes",
                columns: new[] { "LeaveTypeId", "LeaveDescr", "TypeofLeave" },
                values: new object[,]
                {
                    { 1, "Ordinary vacation", "Holiday" },
                    { 2, "Time off to take care of children", "Child-care" },
                    { 3, "For things like hospital appointments", "Personal" },
                    { 4, "If you are to sick to work today", "Sick" },
                    { 5, "Education", "Education" }
                });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "EmpId", "BirthDate", "DepartmentId", "FirstName", "LastName" },
                values: new object[,]
                {
                    { 1, new DateTime(2001, 7, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Andreas", "Fors" },
                    { 2, new DateTime(1993, 12, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, "Johanna", "Marklund" },
                    { 3, new DateTime(1995, 6, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, "Axel", "Wennström" },
                    { 4, new DateTime(1992, 8, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, "Fredrik", "Engström" },
                    { 5, new DateTime(1990, 11, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "Nicklas", "Karlsson" },
                    { 6, new DateTime(1995, 10, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Nadine", "Ullström" },
                    { 7, new DateTime(2002, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Nino", "Olivetto" },
                    { 8, new DateTime(1980, 4, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "Roger", "Zheng" }
                });

            migrationBuilder.InsertData(
                table: "Leaves",
                columns: new[] { "LeaveId", "CreateDate", "EndDate", "FkEmpId", "FkLeaveTypeId", "LeaveNotes", "StartDate" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 3, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, 5, "AI-course", new DateTime(2024, 2, 25, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 3, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 1, "Vacation", new DateTime(2024, 3, 20, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 3, new DateTime(2024, 4, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 4, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 2, "Day care closed", new DateTime(2024, 4, 10, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 4, new DateTime(2024, 4, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 4, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, 4, "Fever", new DateTime(2024, 4, 2, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 5, new DateTime(2024, 4, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 4, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 2, "children with fever", new DateTime(2024, 4, 15, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 6, new DateTime(2024, 4, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 4, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), 7, 3, "Doctors appointment", new DateTime(2024, 4, 25, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "EmpId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "EmpId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "EmpId",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "EmpId",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Leaves",
                keyColumn: "LeaveId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Leaves",
                keyColumn: "LeaveId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Leaves",
                keyColumn: "LeaveId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Leaves",
                keyColumn: "LeaveId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Leaves",
                keyColumn: "LeaveId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Leaves",
                keyColumn: "LeaveId",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "DepartmentId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "EmpId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "EmpId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "EmpId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "EmpId",
                keyValue: 7);

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
                table: "LeaveTypes",
                keyColumn: "LeaveTypeId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "DepartmentId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "DepartmentId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "DepartmentId",
                keyValue: 4);
        }
    }
}
