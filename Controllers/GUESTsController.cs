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
    public class GUESTsController : Controller
    {
        private readonly AdventureLandWebappContext _context;

        public GUESTsController(AdventureLandWebappContext context)
        {
            _context = context;
        }

        // GET: GUESTs
        public async Task<IActionResult> Index()
        {
              return _context.GUEST != null ? 
                          View(await _context.GUEST.ToListAsync()) :
                          Problem("Entity set 'AdventureLandWebappContext.GUEST'  is null.");
        }

        // GET: GUESTs/Details/5
        [Authorize(Roles = "Admin")] // controles access based on roles
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.GUEST == null)
            {
                return NotFound();
            }

            var gUEST = await _context.GUEST
                .FirstOrDefaultAsync(m => m.GuestID == id);
            if (gUEST == null)
            {
                return NotFound();
            }

            return View(gUEST);
        }

        // GET: GUESTs/Create
        [Authorize]
        public IActionResult Create()
        {
            return View();
        }

        // POST: GUESTs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("GuestID,FName,LName,DOB,Phone_Number,Height")] GUEST gUEST)
        {
            if (ModelState.IsValid)
            {
                _context.Add(gUEST);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(gUEST);
        }

        // GET: GUESTs/Edit/5
        [Authorize]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.GUEST == null)
            {
                return NotFound();
            }

            var gUEST = await _context.GUEST.FindAsync(id);
            if (gUEST == null)
            {
                return NotFound();
            }
            return View(gUEST);
        }

        // POST: GUESTs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("GuestID,FName,LName,DOB,Phone_Number,Height")] GUEST gUEST)
        {
            if (id != gUEST.GuestID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(gUEST);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!GUESTExists(gUEST.GuestID))
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
            return View(gUEST);
        }

        // GET: GUESTs/Delete/5
        [Authorize]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.GUEST == null)
            {
                return NotFound();
            }

            var gUEST = await _context.GUEST
                .FirstOrDefaultAsync(m => m.GuestID == id);
            if (gUEST == null)
            {
                return NotFound();
            }

            return View(gUEST);
        }

        // POST: GUESTs/Delete/5
        [Authorize]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.GUEST == null)
            {
                return Problem("Entity set 'AdventureLandWebappContext.GUEST'  is null.");
            }
            var gUEST = await _context.GUEST.FindAsync(id);
            if (gUEST != null)
            {
                _context.GUEST.Remove(gUEST);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool GUESTExists(int id)
        {
          return (_context.GUEST?.Any(e => e.GuestID == id)).GetValueOrDefault();
        }
    }
}
