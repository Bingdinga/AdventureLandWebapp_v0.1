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
    public class PERSONNEL_WORK_RECController : Controller
    {
        private readonly AdventureLandWebappContext _context;

        public PERSONNEL_WORK_RECController(AdventureLandWebappContext context)
        {
            _context = context;
        }

        // GET: PERSONNEL_WORK_REC
        public async Task<IActionResult> Index()
        {
              return _context.PERSONNEL_WORK_REC != null ? 
                          View(await _context.PERSONNEL_WORK_REC.ToListAsync()) :
                          Problem("Entity set 'AdventureLandWebappContext.PERSONNEL_WORK_REC'  is null.");
        }

        // GET: PERSONNEL_WORK_REC/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.PERSONNEL_WORK_REC == null)
            {
                return NotFound();
            }

            var pERSONNEL_WORK_REC = await _context.PERSONNEL_WORK_REC
                .FirstOrDefaultAsync(m => m.Id == id);
            if (pERSONNEL_WORK_REC == null)
            {
                return NotFound();
            }

            return View(pERSONNEL_WORK_REC);
        }

        // GET: PERSONNEL_WORK_REC/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: PERSONNEL_WORK_REC/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,EmployeeID,VenueID,work_started,work_ended")] PERSONNEL_WORK_REC pERSONNEL_WORK_REC)
        {
            if (ModelState.IsValid)
            {
                _context.Add(pERSONNEL_WORK_REC);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(pERSONNEL_WORK_REC);
        }

        // GET: PERSONNEL_WORK_REC/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.PERSONNEL_WORK_REC == null)
            {
                return NotFound();
            }

            var pERSONNEL_WORK_REC = await _context.PERSONNEL_WORK_REC.FindAsync(id);
            if (pERSONNEL_WORK_REC == null)
            {
                return NotFound();
            }
            return View(pERSONNEL_WORK_REC);
        }

        // POST: PERSONNEL_WORK_REC/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,EmployeeID,VenueID,work_started,work_ended")] PERSONNEL_WORK_REC pERSONNEL_WORK_REC)
        {
            if (id != pERSONNEL_WORK_REC.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(pERSONNEL_WORK_REC);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PERSONNEL_WORK_RECExists(pERSONNEL_WORK_REC.Id))
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
            return View(pERSONNEL_WORK_REC);
        }

        // GET: PERSONNEL_WORK_REC/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.PERSONNEL_WORK_REC == null)
            {
                return NotFound();
            }

            var pERSONNEL_WORK_REC = await _context.PERSONNEL_WORK_REC
                .FirstOrDefaultAsync(m => m.Id == id);
            if (pERSONNEL_WORK_REC == null)
            {
                return NotFound();
            }

            return View(pERSONNEL_WORK_REC);
        }

        // POST: PERSONNEL_WORK_REC/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.PERSONNEL_WORK_REC == null)
            {
                return Problem("Entity set 'AdventureLandWebappContext.PERSONNEL_WORK_REC'  is null.");
            }
            var pERSONNEL_WORK_REC = await _context.PERSONNEL_WORK_REC.FindAsync(id);
            if (pERSONNEL_WORK_REC != null)
            {
                _context.PERSONNEL_WORK_REC.Remove(pERSONNEL_WORK_REC);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PERSONNEL_WORK_RECExists(int id)
        {
          return (_context.PERSONNEL_WORK_REC?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
