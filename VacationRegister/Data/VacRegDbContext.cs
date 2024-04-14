using Microsoft.EntityFrameworkCore;
using VacationRegister.Models;

namespace VacationRegister.Data
{
    public class VacRegDbContext : DbContext
    {
        public VacRegDbContext(DbContextOptions<VacRegDbContext> options) : base(options)
        {
            
        }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<LeaveType> LeaveTypes { get; set; }
        public DbSet<Leave> Leaves { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>().HasData(
                new Employee() 
                {
                    EmpId = 1,
                    FirstName = "Andreas", 
                    LastName = "Fors", 
                    DepartmentId = 1, 
                    BirthDate = new DateTime(2001, 07, 13)},
                new Employee()
                {
                    EmpId = 2,
                    FirstName = "Johanna",
                    LastName = "Marklund",
                    DepartmentId = 3,
                    BirthDate = new DateTime(1993, 12, 20)
                },
                new Employee()
                {
                    EmpId = 3,
                    FirstName = "Axel",
                    LastName = "Wennström",
                    DepartmentId = 4,
                    BirthDate = new DateTime(1995, 06, 13)
                },
                new Employee()
                {
                    EmpId = 4,
                    FirstName = "Fredrik",
                    LastName = "Engström",
                    DepartmentId = 3,
                    BirthDate = new DateTime(1992, 08, 24)
                },
                new Employee()
                {
                    EmpId = 5,
                    FirstName = "Nicklas",
                    LastName = "Karlsson",
                    DepartmentId = 2,
                    BirthDate = new DateTime(1990, 11, 09)
                },
                new Employee()
                {
                    EmpId = 6,
                    FirstName = "Nadine",
                    LastName = "Ullström",
                    DepartmentId = 1,
                    BirthDate = new DateTime(1995, 10, 24)
                },
                new Employee()
                {
                    EmpId = 7,
                    FirstName = "Nino",
                    LastName = "Olivetto",
                    DepartmentId = 1,
                    BirthDate = new DateTime(2002, 02, 01)
                },
                new Employee()
                {
                    EmpId = 8,
                    FirstName = "Roger",
                    LastName = "Zheng",
                    DepartmentId = 2,
                    BirthDate = new DateTime(1980, 04, 26)
                }
                );
            modelBuilder.Entity<LeaveType>().HasData(
                new LeaveType() {LeaveTypeId = 1, TypeofLeave = "Holiday", LeaveDescr = "Ordinary vacation"},
                new LeaveType() {LeaveTypeId = 2, TypeofLeave = "Child-care", LeaveDescr = "Time off to take care of children" },
                new LeaveType() {LeaveTypeId = 3, TypeofLeave = "Personal", LeaveDescr = "For things like hospital appointments" },
                new LeaveType() {LeaveTypeId = 4, TypeofLeave = "Sick", LeaveDescr = "If you are to sick to work today" },
                new LeaveType() {LeaveTypeId = 5, TypeofLeave = "Education", LeaveDescr = "Education"}
                );
            modelBuilder.Entity<Department>().HasData(
                new Department() {DepartmentId = 1, DepartmentName = "Economics"},
                new Department() {DepartmentId = 2, DepartmentName = "Administration"},
                new Department() {DepartmentId = 3, DepartmentName = "Development"},
                new Department() {DepartmentId = 4, DepartmentName = "Sales" }
                );
            modelBuilder.Entity<Leave>().HasData(
                 new Leave()
                 {
                     LeaveId = 1,
                     StartDate = new DateTime(2024, 02, 25),
                     EndDate = new DateTime(2024, 03, 05),
                     FkLeaveTypeId = 5,
                     LeaveNotes = "AI-course",
                     FkEmpId = 3,
                     CreateDate = new DateTime(2024, 02, 01)
                 },
                new Leave()
                {
                    LeaveId = 2,
                    StartDate = new DateTime(2024, 03, 20),
                    EndDate = new DateTime(2024, 03, 28),
                    FkLeaveTypeId = 1,
                    LeaveNotes = "Vacation",
                    FkEmpId = 1,
                    CreateDate = new DateTime(2024, 01, 01)
                },
                new Leave()
                {
                    LeaveId = 3,
                    StartDate = new DateTime(2024, 04, 10),
                    EndDate = new DateTime(2024, 04, 16),
                    FkLeaveTypeId = 2,
                    LeaveNotes = "Day care closed",
                    FkEmpId = 1,
                    CreateDate = new DateTime(2024, 04, 05)
                },
                new Leave()
                {
                    LeaveId = 4,
                    StartDate = new DateTime(2024, 04, 02),
                    EndDate = new DateTime(2024, 04, 04),
                    FkLeaveTypeId = 4,
                    LeaveNotes = "Fever",
                    FkEmpId = 3,
                    CreateDate = new DateTime(2024, 04, 02)
                },
                new Leave()
                {
                    LeaveId = 5,
                    StartDate = new DateTime(2024, 04, 15),
                    EndDate = new DateTime(2024, 04, 16),
                    FkLeaveTypeId = 2,
                    LeaveNotes = "children with fever",
                    FkEmpId = 2,
                    CreateDate = new DateTime(2024, 04, 14)
                },
                new Leave()
                {
                    LeaveId = 6,
                    StartDate = new DateTime(2024, 04, 25),
                    EndDate = new DateTime(2024, 04, 26),
                    FkLeaveTypeId = 3,
                    LeaveNotes = "Doctors appointment",
                    FkEmpId = 7,
                    CreateDate = new DateTime(2024, 04, 22)
                }
                );
            
        }
    }
}
