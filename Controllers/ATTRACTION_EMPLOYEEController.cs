using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AdventureLandWebapp.Data;
using AdventureLandWebapp.Models;

namespace AdventureLandWebapp.Controllers
{
    public class ATTRACTION_EMPLOYEEController : Controller
    {
        private readonly AdventureLandWebappContext _context;

        public ATTRACTION_EMPLOYEEController(AdventureLandWebappContext context)
        {
            _context = context;
        }

        // GET: ATTRACTION_EMPLOYEE
        public async Task<IActionResult> Index()
        {
              return _context.ATTRACTION_EMPLOYEE != null ? 
                          View(await _context.ATTRACTION_EMPLOYEE.ToListAsync()) :
                          Problem("Entity set 'AdventureLandWebappContext.ATTRACTION_EMPLOYEE'  is null.");
        }

        // GET: ATTRACTION_EMPLOYEE/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.ATTRACTION_EMPLOYEE == null)
            {
                return NotFound();
            }

            var aTTRACTION_EMPLOYEE = await _context.ATTRACTION_EMPLOYEE
                .FirstOrDefaultAsync(m => m.Id == id);
            if (aTTRACTION_EMPLOYEE == null)
            {
                return NotFound();
            }

            return View(aTTRACTION_EMPLOYEE);
        }

        // GET: ATTRACTION_EMPLOYEE/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ATTRACTION_EMPLOYEE/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,EmployeeID,AttractionID")] ATTRACTION_EMPLOYEE aTTRACTION_EMPLOYEE)
        {
            if (ModelState.IsValid)
            {
                _context.Add(aTTRACTION_EMPLOYEE);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(aTTRACTION_EMPLOYEE);
        }

        // GET: ATTRACTION_EMPLOYEE/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.ATTRACTION_EMPLOYEE == null)
            {
                return NotFound();
            }

            var aTTRACTION_EMPLOYEE = await _context.ATTRACTION_EMPLOYEE.FindAsync(id);
            if (aTTRACTION_EMPLOYEE == null)
            {
                return NotFound();
            }
            return View(aTTRACTION_EMPLOYEE);
        }

        // POST: ATTRACTION_EMPLOYEE/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,EmployeeID,AttractionID")] ATTRACTION_EMPLOYEE aTTRACTION_EMPLOYEE)
        {
            if (id != aTTRACTION_EMPLOYEE.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(aTTRACTION_EMPLOYEE);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ATTRACTION_EMPLOYEEExists(aTTRACTION_EMPLOYEE.Id))
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
            return View(aTTRACTION_EMPLOYEE);
        }

        // GET: ATTRACTION_EMPLOYEE/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.ATTRACTION_EMPLOYEE == null)
            {
                return NotFound();
            }

            var aTTRACTION_EMPLOYEE = await _context.ATTRACTION_EMPLOYEE
                .FirstOrDefaultAsync(m => m.Id == id);
            if (aTTRACTION_EMPLOYEE == null)
            {
                return NotFound();
            }

            return View(aTTRACTION_EMPLOYEE);
        }

        // POST: ATTRACTION_EMPLOYEE/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.ATTRACTION_EMPLOYEE == null)
            {
                return Problem("Entity set 'AdventureLandWebappContext.ATTRACTION_EMPLOYEE'  is null.");
            }
            var aTTRACTION_EMPLOYEE = await _context.ATTRACTION_EMPLOYEE.FindAsync(id);
            if (aTTRACTION_EMPLOYEE != null)
            {
                _context.ATTRACTION_EMPLOYEE.Remove(aTTRACTION_EMPLOYEE);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ATTRACTION_EMPLOYEEExists(int id)
        {
          return (_context.ATTRACTION_EMPLOYEE?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
