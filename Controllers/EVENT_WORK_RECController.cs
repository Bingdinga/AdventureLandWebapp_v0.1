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
    public class EVENT_WORK_RECController : Controller
    {
        private readonly AdventureLandWebappContext _context;

        public EVENT_WORK_RECController(AdventureLandWebappContext context)
        {
            _context = context;
        }

        // GET: EVENT_WORK_REC
        public async Task<IActionResult> Index()
        {
              return _context.EVENT_WORK_REC != null ? 
                          View(await _context.EVENT_WORK_REC.ToListAsync()) :
                          Problem("Entity set 'AdventureLandWebappContext.EVENT_WORK_REC'  is null.");
        }

        // GET: EVENT_WORK_REC/Details/5
        [Authorize]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.EVENT_WORK_REC == null)
            {
                return NotFound();
            }

            var eVENT_WORK_REC = await _context.EVENT_WORK_REC
                .FirstOrDefaultAsync(m => m.Id == id);
            if (eVENT_WORK_REC == null)
            {
                return NotFound();
            }

            return View(eVENT_WORK_REC);
        }

        // GET: EVENT_WORK_REC/Create
        [Authorize]
        public IActionResult Create()
        {
            return View();
        }

        // POST: EVENT_WORK_REC/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,EmployeeID,Work_Started,Work_Completed")] EVENT_WORK_REC eVENT_WORK_REC)
        {
            if (ModelState.IsValid)
            {
                _context.Add(eVENT_WORK_REC);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(eVENT_WORK_REC);
        }

        // GET: EVENT_WORK_REC/Edit/5
        [Authorize]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.EVENT_WORK_REC == null)
            {
                return NotFound();
            }

            var eVENT_WORK_REC = await _context.EVENT_WORK_REC.FindAsync(id);
            if (eVENT_WORK_REC == null)
            {
                return NotFound();
            }
            return View(eVENT_WORK_REC);
        }

        // POST: EVENT_WORK_REC/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,EmployeeID,Work_Started,Work_Completed")] EVENT_WORK_REC eVENT_WORK_REC)
        {
            if (id != eVENT_WORK_REC.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(eVENT_WORK_REC);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EVENT_WORK_RECExists(eVENT_WORK_REC.Id))
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
            return View(eVENT_WORK_REC);
        }

        // GET: EVENT_WORK_REC/Delete/5
        [Authorize]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.EVENT_WORK_REC == null)
            {
                return NotFound();
            }

            var eVENT_WORK_REC = await _context.EVENT_WORK_REC
                .FirstOrDefaultAsync(m => m.Id == id);
            if (eVENT_WORK_REC == null)
            {
                return NotFound();
            }

            return View(eVENT_WORK_REC);
        }

        // POST: EVENT_WORK_REC/Delete/5
        [Authorize]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.EVENT_WORK_REC == null)
            {
                return Problem("Entity set 'AdventureLandWebappContext.EVENT_WORK_REC'  is null.");
            }
            var eVENT_WORK_REC = await _context.EVENT_WORK_REC.FindAsync(id);
            if (eVENT_WORK_REC != null)
            {
                _context.EVENT_WORK_REC.Remove(eVENT_WORK_REC);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EVENT_WORK_RECExists(int id)
        {
          return (_context.EVENT_WORK_REC?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
