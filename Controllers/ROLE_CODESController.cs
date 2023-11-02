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
    public class ROLE_CODESController : Controller
    {
        private readonly AdventureLandWebappContext _context;

        public ROLE_CODESController(AdventureLandWebappContext context)
        {
            _context = context;
        }

        // GET: ROLE_CODES
        public async Task<IActionResult> Index()
        {
              return _context.ROLE_CODES != null ? 
                          View(await _context.ROLE_CODES.ToListAsync()) :
                          Problem("Entity set 'AdventureLandWebappContext.ROLE_CODES'  is null.");
        }

        // GET: ROLE_CODES/Details/5
        [Authorize]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.ROLE_CODES == null)
            {
                return NotFound();
            }

            var rOLE_CODES = await _context.ROLE_CODES
                .FirstOrDefaultAsync(m => m.Id == id);
            if (rOLE_CODES == null)
            {
                return NotFound();
            }

            return View(rOLE_CODES);
        }

        // GET: ROLE_CODES/Create
        [Authorize]
        public IActionResult Create()
        {
            return View();
        }

        // POST: ROLE_CODES/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Role_Code,Role_Desc")] ROLE_CODES rOLE_CODES)
        {
            if (ModelState.IsValid)
            {
                _context.Add(rOLE_CODES);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(rOLE_CODES);
        }

        // GET: ROLE_CODES/Edit/5
        [Authorize]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.ROLE_CODES == null)
            {
                return NotFound();
            }

            var rOLE_CODES = await _context.ROLE_CODES.FindAsync(id);
            if (rOLE_CODES == null)
            {
                return NotFound();
            }
            return View(rOLE_CODES);
        }

        // POST: ROLE_CODES/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Role_Code,Role_Desc")] ROLE_CODES rOLE_CODES)
        {
            if (id != rOLE_CODES.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(rOLE_CODES);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ROLE_CODESExists(rOLE_CODES.Id))
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
            return View(rOLE_CODES);
        }

        // GET: ROLE_CODES/Delete/5
        [Authorize]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.ROLE_CODES == null)
            {
                return NotFound();
            }

            var rOLE_CODES = await _context.ROLE_CODES
                .FirstOrDefaultAsync(m => m.Id == id);
            if (rOLE_CODES == null)
            {
                return NotFound();
            }

            return View(rOLE_CODES);
        }

        // POST: ROLE_CODES/Delete/5
        [Authorize]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.ROLE_CODES == null)
            {
                return Problem("Entity set 'AdventureLandWebappContext.ROLE_CODES'  is null.");
            }
            var rOLE_CODES = await _context.ROLE_CODES.FindAsync(id);
            if (rOLE_CODES != null)
            {
                _context.ROLE_CODES.Remove(rOLE_CODES);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ROLE_CODESExists(int id)
        {
          return (_context.ROLE_CODES?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
