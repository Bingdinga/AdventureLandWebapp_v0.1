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
    public class TICKET_TYPESController : Controller
    {
        private readonly AdventureLandWebappContext _context;

        public TICKET_TYPESController(AdventureLandWebappContext context)
        {
            _context = context;
        }

        // GET: TICKET_TYPES
        public async Task<IActionResult> Index()
        {
              return _context.TICKET_TYPES != null ? 
                          View(await _context.TICKET_TYPES.ToListAsync()) :
                          Problem("Entity set 'AdventureLandWebappContext.TICKET_TYPES'  is null.");
        }

        // GET: TICKET_TYPES/Details/5
        [Authorize]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.TICKET_TYPES == null)
            {
                return NotFound();
            }

            var tICKET_TYPES = await _context.TICKET_TYPES
                .FirstOrDefaultAsync(m => m.ID == id);
            if (tICKET_TYPES == null)
            {
                return NotFound();
            }

            return View(tICKET_TYPES);
        }

        // GET: TICKET_TYPES/Create
        [Authorize]
        public IActionResult Create()
        {
            return View();
        }

        // POST: TICKET_TYPES/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Ticket_Code,Ticket_Type_Desc")] TICKET_TYPES tICKET_TYPES)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tICKET_TYPES);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tICKET_TYPES);
        }

        // GET: TICKET_TYPES/Edit/5
        [Authorize]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.TICKET_TYPES == null)
            {
                return NotFound();
            }

            var tICKET_TYPES = await _context.TICKET_TYPES.FindAsync(id);
            if (tICKET_TYPES == null)
            {
                return NotFound();
            }
            return View(tICKET_TYPES);
        }

        // POST: TICKET_TYPES/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Ticket_Code,Ticket_Type_Desc")] TICKET_TYPES tICKET_TYPES)
        {
            if (id != tICKET_TYPES.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tICKET_TYPES);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TICKET_TYPESExists(tICKET_TYPES.ID))
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
            return View(tICKET_TYPES);
        }

        // GET: TICKET_TYPES/Delete/5
        [Authorize]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.TICKET_TYPES == null)
            {
                return NotFound();
            }

            var tICKET_TYPES = await _context.TICKET_TYPES
                .FirstOrDefaultAsync(m => m.ID == id);
            if (tICKET_TYPES == null)
            {
                return NotFound();
            }

            return View(tICKET_TYPES);
        }

        // POST: TICKET_TYPES/Delete/5
        [Authorize]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.TICKET_TYPES == null)
            {
                return Problem("Entity set 'AdventureLandWebappContext.TICKET_TYPES'  is null.");
            }
            var tICKET_TYPES = await _context.TICKET_TYPES.FindAsync(id);
            if (tICKET_TYPES != null)
            {
                _context.TICKET_TYPES.Remove(tICKET_TYPES);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TICKET_TYPESExists(int id)
        {
          return (_context.TICKET_TYPES?.Any(e => e.ID == id)).GetValueOrDefault();
        }
    }
}
