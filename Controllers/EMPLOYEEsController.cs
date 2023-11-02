using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AdventureLandWebapp.Data;
using AdventureLandWebapp.Models;
using Microsoft.AspNetCore.Authorization;

namespace AdventureLandWebapp.Controllers
{
    public class EMPLOYEEsController : Controller
    {
        private readonly AdventureLandWebappContext _context;

        public EMPLOYEEsController(AdventureLandWebappContext context)
        {
            _context = context;
        }

        // GET: EMPLOYEEs
        public async Task<IActionResult> Index()
        {
              return _context.EMPLOYEE != null ? 
                          View(await _context.EMPLOYEE.ToListAsync()) :
                          Problem("Entity set 'AdventureLandWebappContext.EMPLOYEE'  is null.");
        }

        // GET: EMPLOYEEs/Details/5
        [Authorize]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.EMPLOYEE == null)
            {
                return NotFound();
            }

            var eMPLOYEE = await _context.EMPLOYEE
                .FirstOrDefaultAsync(m => m.EmployeeID == id);
            if (eMPLOYEE == null)
            {
                return NotFound();
            }

            return View(eMPLOYEE);
        }

        // GET: EMPLOYEEs/Create
        [Authorize]
        public IActionResult Create()
        {
            return View();
        }

        // POST: EMPLOYEEs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("EmployeeID,SSN,SuperID,Role,Auth_Level,FName,LName,Phone_Number,DOB,Salary,Hourly_Wage")] EMPLOYEE eMPLOYEE)
        {
            if (ModelState.IsValid)
            {
                _context.Add(eMPLOYEE);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(eMPLOYEE);
        }

        // GET: EMPLOYEEs/Edit/5
        [Authorize]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.EMPLOYEE == null)
            {
                return NotFound();
            }

            var eMPLOYEE = await _context.EMPLOYEE.FindAsync(id);
            if (eMPLOYEE == null)
            {
                return NotFound();
            }
            return View(eMPLOYEE);
        }

        // POST: EMPLOYEEs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("EmployeeID,SSN,SuperID,Role,Auth_Level,FName,LName,Phone_Number,DOB,Salary,Hourly_Wage")] EMPLOYEE eMPLOYEE)
        {
            if (id != eMPLOYEE.EmployeeID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(eMPLOYEE);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EMPLOYEEExists(eMPLOYEE.EmployeeID))
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
            return View(eMPLOYEE);
        }

        // GET: EMPLOYEEs/Delete/5
        [Authorize]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.EMPLOYEE == null)
            {
                return NotFound();
            }

            var eMPLOYEE = await _context.EMPLOYEE
                .FirstOrDefaultAsync(m => m.EmployeeID == id);
            if (eMPLOYEE == null)
            {
                return NotFound();
            }

            return View(eMPLOYEE);
        }

        // POST: EMPLOYEEs/Delete/5
        [Authorize]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.EMPLOYEE == null)
            {
                return Problem("Entity set 'AdventureLandWebappContext.EMPLOYEE'  is null.");
            }
            var eMPLOYEE = await _context.EMPLOYEE.FindAsync(id);
            if (eMPLOYEE != null)
            {
                _context.EMPLOYEE.Remove(eMPLOYEE);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EMPLOYEEExists(int id)
        {
          return (_context.EMPLOYEE?.Any(e => e.EmployeeID == id)).GetValueOrDefault();
        }
    }
}
