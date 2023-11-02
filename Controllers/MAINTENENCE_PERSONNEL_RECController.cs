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
    public class MAINTENENCE_PERSONNEL_RECController : Controller
    {
        private readonly AdventureLandWebappContext _context;

        public MAINTENENCE_PERSONNEL_RECController(AdventureLandWebappContext context)
        {
            _context = context;
        }

        // GET: MAINTENENCE_PERSONNEL_REC
        public async Task<IActionResult> Index()
        {
              return _context.MAINTENENCE_PERSONNEL_REC != null ? 
                          View(await _context.MAINTENENCE_PERSONNEL_REC.ToListAsync()) :
                          Problem("Entity set 'AdventureLandWebappContext.MAINTENENCE_PERSONNEL_REC'  is null.");
        }

        // GET: MAINTENENCE_PERSONNEL_REC/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.MAINTENENCE_PERSONNEL_REC == null)
            {
                return NotFound();
            }

            var mAINTENENCE_PERSONNEL_REC = await _context.MAINTENENCE_PERSONNEL_REC
                .FirstOrDefaultAsync(m => m.Id == id);
            if (mAINTENENCE_PERSONNEL_REC == null)
            {
                return NotFound();
            }

            return View(mAINTENENCE_PERSONNEL_REC);
        }

        // GET: MAINTENENCE_PERSONNEL_REC/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: MAINTENENCE_PERSONNEL_REC/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Maint_RecID,EmployeeID,work_started,work_ended")] MAINTENENCE_PERSONNEL_REC mAINTENENCE_PERSONNEL_REC)
        {
            if (ModelState.IsValid)
            {
                _context.Add(mAINTENENCE_PERSONNEL_REC);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(mAINTENENCE_PERSONNEL_REC);
        }

        // GET: MAINTENENCE_PERSONNEL_REC/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.MAINTENENCE_PERSONNEL_REC == null)
            {
                return NotFound();
            }

            var mAINTENENCE_PERSONNEL_REC = await _context.MAINTENENCE_PERSONNEL_REC.FindAsync(id);
            if (mAINTENENCE_PERSONNEL_REC == null)
            {
                return NotFound();
            }
            return View(mAINTENENCE_PERSONNEL_REC);
        }

        // POST: MAINTENENCE_PERSONNEL_REC/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Maint_RecID,EmployeeID,work_started,work_ended")] MAINTENENCE_PERSONNEL_REC mAINTENENCE_PERSONNEL_REC)
        {
            if (id != mAINTENENCE_PERSONNEL_REC.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(mAINTENENCE_PERSONNEL_REC);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MAINTENENCE_PERSONNEL_RECExists(mAINTENENCE_PERSONNEL_REC.Id))
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
            return View(mAINTENENCE_PERSONNEL_REC);
        }

        // GET: MAINTENENCE_PERSONNEL_REC/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.MAINTENENCE_PERSONNEL_REC == null)
            {
                return NotFound();
            }

            var mAINTENENCE_PERSONNEL_REC = await _context.MAINTENENCE_PERSONNEL_REC
                .FirstOrDefaultAsync(m => m.Id == id);
            if (mAINTENENCE_PERSONNEL_REC == null)
            {
                return NotFound();
            }

            return View(mAINTENENCE_PERSONNEL_REC);
        }

        // POST: MAINTENENCE_PERSONNEL_REC/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.MAINTENENCE_PERSONNEL_REC == null)
            {
                return Problem("Entity set 'AdventureLandWebappContext.MAINTENENCE_PERSONNEL_REC'  is null.");
            }
            var mAINTENENCE_PERSONNEL_REC = await _context.MAINTENENCE_PERSONNEL_REC.FindAsync(id);
            if (mAINTENENCE_PERSONNEL_REC != null)
            {
                _context.MAINTENENCE_PERSONNEL_REC.Remove(mAINTENENCE_PERSONNEL_REC);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MAINTENENCE_PERSONNEL_RECExists(int id)
        {
          return (_context.MAINTENENCE_PERSONNEL_REC?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
