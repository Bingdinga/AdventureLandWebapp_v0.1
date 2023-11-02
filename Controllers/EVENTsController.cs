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
    public class EVENTsController : Controller
    {
        private readonly AdventureLandWebappContext _context;

        public EVENTsController(AdventureLandWebappContext context)
        {
            _context = context;
        }

        // GET: EVENTs
        public async Task<IActionResult> Index()
        {
              return _context.EVENT != null ? 
                          View(await _context.EVENT.ToListAsync()) :
                          Problem("Entity set 'AdventureLandWebappContext.EVENT'  is null.");
        }

        // GET: EVENTs/Details/5
        [Authorize]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.EVENT == null)
            {
                return NotFound();
            }

            var eVENT = await _context.EVENT
                .FirstOrDefaultAsync(m => m.EventID == id);
            if (eVENT == null)
            {
                return NotFound();
            }

            return View(eVENT);
        }

        // GET: EVENTs/Create
        [Authorize]
        public IActionResult Create()
        {
            return View();
        }

        // POST: EVENTs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("VenueID,EventID,EventName,Event_Started,Event_Ended")] EVENT eVENT)
        {
            if (ModelState.IsValid)
            {
                _context.Add(eVENT);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(eVENT);
        }

        // GET: EVENTs/Edit/5
        [Authorize]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.EVENT == null)
            {
                return NotFound();
            }

            var eVENT = await _context.EVENT.FindAsync(id);
            if (eVENT == null)
            {
                return NotFound();
            }
            return View(eVENT);
        }

        // POST: EVENTs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("VenueID,EventID,EventName,Event_Started,Event_Ended")] EVENT eVENT)
        {
            if (id != eVENT.EventID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(eVENT);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EVENTExists(eVENT.EventID))
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
            return View(eVENT);
        }

        // GET: EVENTs/Delete/5
        [Authorize]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.EVENT == null)
            {
                return NotFound();
            }

            var eVENT = await _context.EVENT
                .FirstOrDefaultAsync(m => m.EventID == id);
            if (eVENT == null)
            {
                return NotFound();
            }

            return View(eVENT);
        }

        // POST: EVENTs/Delete/5
        [Authorize]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.EVENT == null)
            {
                return Problem("Entity set 'AdventureLandWebappContext.EVENT'  is null.");
            }
            var eVENT = await _context.EVENT.FindAsync(id);
            if (eVENT != null)
            {
                _context.EVENT.Remove(eVENT);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EVENTExists(int id)
        {
          return (_context.EVENT?.Any(e => e.EventID == id)).GetValueOrDefault();
        }
    }
}
