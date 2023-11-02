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
    public class AUTH_CODESController : Controller
    {
        private readonly AdventureLandWebappContext _context;

        public AUTH_CODESController(AdventureLandWebappContext context)
        {
            _context = context;
        }

        // GET: AUTH_CODES
        public async Task<IActionResult> Index()
        {
              return _context.AUTH_CODES != null ? 
                          View(await _context.AUTH_CODES.ToListAsync()) :
                          Problem("Entity set 'AdventureLandWebappContext.AUTH_CODES'  is null.");
        }

        // GET: AUTH_CODES/Details/5
        [Authorize]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.AUTH_CODES == null)
            {
                return NotFound();
            }

            var aUTH_CODES = await _context.AUTH_CODES
                .FirstOrDefaultAsync(m => m.Id == id);
            if (aUTH_CODES == null)
            {
                return NotFound();
            }

            return View(aUTH_CODES);
        }

        // GET: AUTH_CODES/Create
        [Authorize]
        public IActionResult Create()
        {
            return View();
        }

        // POST: AUTH_CODES/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Auth_Code,Auth_Desc")] AUTH_CODES aUTH_CODES)
        {
            if (ModelState.IsValid)
            {
                _context.Add(aUTH_CODES);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(aUTH_CODES);
        }

        // GET: AUTH_CODES/Edit/5
        [Authorize]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.AUTH_CODES == null)
            {
                return NotFound();
            }

            var aUTH_CODES = await _context.AUTH_CODES.FindAsync(id);
            if (aUTH_CODES == null)
            {
                return NotFound();
            }
            return View(aUTH_CODES);
        }

        // POST: AUTH_CODES/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Auth_Code,Auth_Desc")] AUTH_CODES aUTH_CODES)
        {
            if (id != aUTH_CODES.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(aUTH_CODES);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AUTH_CODESExists(aUTH_CODES.Id))
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
            return View(aUTH_CODES);
        }

        // GET: AUTH_CODES/Delete/5
        [Authorize]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.AUTH_CODES == null)
            {
                return NotFound();
            }

            var aUTH_CODES = await _context.AUTH_CODES
                .FirstOrDefaultAsync(m => m.Id == id);
            if (aUTH_CODES == null)
            {
                return NotFound();
            }

            return View(aUTH_CODES);
        }

        // POST: AUTH_CODES/Delete/5
        [Authorize]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.AUTH_CODES == null)
            {
                return Problem("Entity set 'AdventureLandWebappContext.AUTH_CODES'  is null.");
            }
            var aUTH_CODES = await _context.AUTH_CODES.FindAsync(id);
            if (aUTH_CODES != null)
            {
                _context.AUTH_CODES.Remove(aUTH_CODES);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AUTH_CODESExists(int id)
        {
          return (_context.AUTH_CODES?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
