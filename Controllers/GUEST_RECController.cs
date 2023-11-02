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
    public class GUEST_RECController : Controller
    {
        private readonly AdventureLandWebappContext _context;

        public GUEST_RECController(AdventureLandWebappContext context)
        {
            _context = context;
        }

        // GET: GUEST_REC
        public async Task<IActionResult> Index()
        {
              return _context.GUEST_REC != null ? 
                          View(await _context.GUEST_REC.ToListAsync()) :
                          Problem("Entity set 'AdventureLandWebappContext.GUEST_REC'  is null.");
        }

        // GET: GUEST_REC/Details/5
        [Authorize]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.GUEST_REC == null)
            {
                return NotFound();
            }

            var gUEST_REC = await _context.GUEST_REC
                .FirstOrDefaultAsync(m => m.ID == id);
            if (gUEST_REC == null)
            {
                return NotFound();
            }

            return View(gUEST_REC);
        }

        // GET: GUEST_REC/Create
        [Authorize]
        public IActionResult Create()
        {
            return View();
        }

        // POST: GUEST_REC/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,GuestID,TicketID,Arrived,Departed")] GUEST_REC gUEST_REC)
        {
            if (ModelState.IsValid)
            {
                _context.Add(gUEST_REC);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(gUEST_REC);
        }

        // GET: GUEST_REC/Edit/5
        [Authorize]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.GUEST_REC == null)
            {
                return NotFound();
            }

            var gUEST_REC = await _context.GUEST_REC.FindAsync(id);
            if (gUEST_REC == null)
            {
                return NotFound();
            }
            return View(gUEST_REC);
        }

        // POST: GUEST_REC/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,GuestID,TicketID,Arrived,Departed")] GUEST_REC gUEST_REC)
        {
            if (id != gUEST_REC.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(gUEST_REC);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!GUEST_RECExists(gUEST_REC.ID))
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
            return View(gUEST_REC);
        }

        // GET: GUEST_REC/Delete/5
        [Authorize]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.GUEST_REC == null)
            {
                return NotFound();
            }

            var gUEST_REC = await _context.GUEST_REC
                .FirstOrDefaultAsync(m => m.ID == id);
            if (gUEST_REC == null)
            {
                return NotFound();
            }

            return View(gUEST_REC);
        }

        // POST: GUEST_REC/Delete/5
        [Authorize]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.GUEST_REC == null)
            {
                return Problem("Entity set 'AdventureLandWebappContext.GUEST_REC'  is null.");
            }
            var gUEST_REC = await _context.GUEST_REC.FindAsync(id);
            if (gUEST_REC != null)
            {
                _context.GUEST_REC.Remove(gUEST_REC);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool GUEST_RECExists(int id)
        {
          return (_context.GUEST_REC?.Any(e => e.ID == id)).GetValueOrDefault();
        }
    }
}
