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
    public class TICKETsController : Controller
    {
        private readonly AdventureLandWebappContext _context;

        public TICKETsController(AdventureLandWebappContext context)
        {
            _context = context;
        }

        // GET: TICKETs
        public async Task<IActionResult> Index()
        {
              return _context.TICKET != null ? 
                          View(await _context.TICKET.ToListAsync()) :
                          Problem("Entity set 'AdventureLandWebappContext.TICKET'  is null.");
        }

        // GET: TICKETs/Details/5
        [Authorize]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.TICKET == null)
            {
                return NotFound();
            }

            var tICKET = await _context.TICKET
                .FirstOrDefaultAsync(m => m.TicketID == id);
            if (tICKET == null)
            {
                return NotFound();
            }

            return View(tICKET);
        }

        // GET: TICKETs/Create
        [Authorize]
        public IActionResult Create()
        {
            return View();
        }

        // POST: TICKETs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("TicketID,Purchase_Date,Ticket_Type,GuestID,Valid_Through")] TICKET tICKET)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tICKET);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tICKET);
        }

        // GET: TICKETs/Edit/5
        [Authorize]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.TICKET == null)
            {
                return NotFound();
            }

            var tICKET = await _context.TICKET.FindAsync(id);
            if (tICKET == null)
            {
                return NotFound();
            }
            return View(tICKET);
        }

        // POST: TICKETs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("TicketID,Purchase_Date,Ticket_Type,GuestID,Valid_Through")] TICKET tICKET)
        {
            if (id != tICKET.TicketID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tICKET);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TICKETExists(tICKET.TicketID))
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
            return View(tICKET);
        }

        // GET: TICKETs/Delete/5
        [Authorize]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.TICKET == null)
            {
                return NotFound();
            }

            var tICKET = await _context.TICKET
                .FirstOrDefaultAsync(m => m.TicketID == id);
            if (tICKET == null)
            {
                return NotFound();
            }

            return View(tICKET);
        }

        // POST: TICKETs/Delete/5
        [Authorize]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.TICKET == null)
            {
                return Problem("Entity set 'AdventureLandWebappContext.TICKET'  is null.");
            }
            var tICKET = await _context.TICKET.FindAsync(id);
            if (tICKET != null)
            {
                _context.TICKET.Remove(tICKET);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TICKETExists(int id)
        {
          return (_context.TICKET?.Any(e => e.TicketID == id)).GetValueOrDefault();
        }
    }
}
