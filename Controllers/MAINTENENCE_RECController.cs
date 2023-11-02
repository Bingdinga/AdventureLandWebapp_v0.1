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
    public class MAINTENENCE_RECController : Controller
    {
        private readonly AdventureLandWebappContext _context;

        public MAINTENENCE_RECController(AdventureLandWebappContext context)
        {
            _context = context;
        }

        // GET: MAINTENENCE_REC
        public async Task<IActionResult> Index()
        {
              return _context.MAINTENENCE_REC != null ? 
                          View(await _context.MAINTENENCE_REC.ToListAsync()) :
                          Problem("Entity set 'AdventureLandWebappContext.MAINTENENCE_REC'  is null.");
        }

        // GET: MAINTENENCE_REC/Details/5
        [Authorize]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.MAINTENENCE_REC == null)
            {
                return NotFound();
            }

            var mAINTENENCE_REC = await _context.MAINTENENCE_REC
                .FirstOrDefaultAsync(m => m.Id == id);
            if (mAINTENENCE_REC == null)
            {
                return NotFound();
            }

            return View(mAINTENENCE_REC);
        }

        // GET: MAINTENENCE_REC/Create
        [Authorize]
        public IActionResult Create()
        {
            return View();
        }

        // POST: MAINTENENCE_REC/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,AttractionID,Main_Started,Main_Ended")] MAINTENENCE_REC mAINTENENCE_REC)
        {
            if (ModelState.IsValid)
            {
                _context.Add(mAINTENENCE_REC);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(mAINTENENCE_REC);
        }

        // GET: MAINTENENCE_REC/Edit/5
        [Authorize]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.MAINTENENCE_REC == null)
            {
                return NotFound();
            }

            var mAINTENENCE_REC = await _context.MAINTENENCE_REC.FindAsync(id);
            if (mAINTENENCE_REC == null)
            {
                return NotFound();
            }
            return View(mAINTENENCE_REC);
        }

        // POST: MAINTENENCE_REC/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,AttractionID,Main_Started,Main_Ended")] MAINTENENCE_REC mAINTENENCE_REC)
        {
            if (id != mAINTENENCE_REC.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(mAINTENENCE_REC);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MAINTENENCE_RECExists(mAINTENENCE_REC.Id))
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
            return View(mAINTENENCE_REC);
        }

        // GET: MAINTENENCE_REC/Delete/5
        [Authorize]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.MAINTENENCE_REC == null)
            {
                return NotFound();
            }

            var mAINTENENCE_REC = await _context.MAINTENENCE_REC
                .FirstOrDefaultAsync(m => m.Id == id);
            if (mAINTENENCE_REC == null)
            {
                return NotFound();
            }

            return View(mAINTENENCE_REC);
        }

        // POST: MAINTENENCE_REC/Delete/5
        [Authorize]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.MAINTENENCE_REC == null)
            {
                return Problem("Entity set 'AdventureLandWebappContext.MAINTENENCE_REC'  is null.");
            }
            var mAINTENENCE_REC = await _context.MAINTENENCE_REC.FindAsync(id);
            if (mAINTENENCE_REC != null)
            {
                _context.MAINTENENCE_REC.Remove(mAINTENENCE_REC);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MAINTENENCE_RECExists(int id)
        {
          return (_context.MAINTENENCE_REC?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
