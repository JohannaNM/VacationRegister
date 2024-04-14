using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using VacationRegister.Data;
using VacationRegister.Models;

namespace VacationRegister.Controllers
{
    public class LeavesController : Controller
    {
        private readonly VacRegDbContext _context;

        public LeavesController(VacRegDbContext context)
        {
            _context = context;
        }

        // GET: Leaves
        public async Task<IActionResult> Index(string searchString, DateTime? start, DateTime? end, string sortOrder, string currentFilter, int? pageNumber)
        {
            if (_context.Leaves == null)
            {
                return Problem("Entity set 'VacRegDbContext.Leaves' is null.");
            }

            ViewData["CurrentSort"] = sortOrder;
            ViewData["NameSortParam"] = String.IsNullOrEmpty(sortOrder) ? "firstName" : "lastName";
            ViewData["DateSortParam"] = sortOrder == "Date" ? "Date" : "" ;
            
            if (searchString!= null)
            {
                pageNumber = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            ViewData["CurrentFilter"] = searchString;
            var leaves = from l in _context.Leaves
                             .Include(l => l.Employee)
                             .Include(l => l.LeaveType)
                             select l;

            if (!String.IsNullOrEmpty(searchString))
            {
                leaves = leaves.Where(s => s.Employee.FirstName!.Contains(searchString)
                                    || s.Employee.LastName!.Contains(searchString));
            }

            if (start.HasValue)
            {
                leaves = leaves.Where(l => l.CreateDate >= start && l.CreateDate <= end);
            }
            switch (sortOrder)
            {
                case "firstName":
                    leaves = leaves.OrderBy(l => l.Employee.FirstName);
                    break;
                case "Date":
                    leaves = leaves.OrderBy(l => l.StartDate);
                    break;
                case "lastName":
                    leaves = leaves.OrderBy(l => l.Employee.LastName);
                    break;
                default:
                    leaves = leaves.OrderByDescending(l => l.StartDate);
                    break;
            }
            int pageSize = 6;
            return View(await PaginatedList<Leave>.CreateAsync(leaves.AsNoTracking(), pageNumber ?? 1, pageSize));


            //return View(await leaves.AsNoTracking().ToListAsync());


        }

        // GET: Leaves/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var leave = await _context.Leaves
                .Include(l => l.Employee)
                .Include(l => l.LeaveType)
                .FirstOrDefaultAsync(m => m.LeaveId == id);
            if (leave == null)
            {
                return NotFound();
            }

            return View(leave);
        }

        // GET: Leaves/Create
        public IActionResult Create()
        {
            ViewData["FkEmpId"] = new SelectList(_context.Employees, "EmpId", "Fullname");
            ViewData["FkLeaveTypeId"] = new SelectList(_context.LeaveTypes, "LeaveTypeId", "TypeofLeave");
            return View();
        }

        // POST: Leaves/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("LeaveId,StartDate,EndDate,LeaveNotes,CreateDate,FkLeaveTypeId,FkEmpId")] Leave leave)
        {
            if (ModelState.IsValid)
            {
                _context.Add(leave);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["FkEmpId"] = new SelectList(_context.Employees, "EmpId", "FirstName", leave.FkEmpId);
            ViewData["FkLeaveTypeId"] = new SelectList(_context.LeaveTypes, "LeaveTypeId", "LeaveTypeId", leave.FkLeaveTypeId);
            return View(leave);
        }

        // GET: Leaves/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var leave = await _context.Leaves.FindAsync(id);
            if (leave == null)
            {
                return NotFound();
            }
            ViewData["FkEmpId"] = new SelectList(_context.Employees, "EmpId", "FirstName", leave.FkEmpId);
            ViewData["FkLeaveTypeId"] = new SelectList(_context.LeaveTypes, "LeaveTypeId", "LeaveTypeId", leave.FkLeaveTypeId);
            return View(leave);
        }

        // POST: Leaves/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("LeaveId,StartDate,EndDate,LeaveNotes,CreateDate,FkLeaveTypeId,FkEmpId")] Leave leave)
        {
            if (id != leave.LeaveId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(leave);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LeaveExists(leave.LeaveId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["FkEmpId"] = new SelectList(_context.Employees, "EmpId", "FirstName", leave.FkEmpId);
            ViewData["FkLeaveTypeId"] = new SelectList(_context.LeaveTypes, "LeaveTypeId", "LeaveTypeId", leave.FkLeaveTypeId);
            return View(leave);
        }

        // GET: Leaves/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var leave = await _context.Leaves
                .Include(l => l.Employee)
                .Include(l => l.LeaveType)
                .FirstOrDefaultAsync(m => m.LeaveId == id);
            if (leave == null)
            {
                return NotFound();
            }

            return View(leave);
        }

        // POST: Leaves/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var leave = await _context.Leaves.FindAsync(id);
            if (leave != null)
            {
                _context.Leaves.Remove(leave);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LeaveExists(int id)
        {
            return _context.Leaves.Any(e => e.LeaveId == id);
        }
    }
}
