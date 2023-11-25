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
    public class ATTRACTIONsController : Controller
    {
        private readonly AdventureLandWebappContext _context;

        public ATTRACTIONsController(AdventureLandWebappContext context)
        {
            _context = context;
        }

        // GET: ATTRACTIONs
        [Authorize]
        public async Task<IActionResult> Index()
        {
              return _context.ATTRACTION != null ? 
                          View(await _context.ATTRACTION.ToListAsync()) :
                          Problem("Entity set 'AdventureLandWebappContext.ATTRACTION'  is null.");
        }

        // GET: ATTRACTIONs/Details/5
        [Authorize]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.ATTRACTION == null)
            {
                return NotFound();
            }

            var aTTRACTION = await _context.ATTRACTION
                .FirstOrDefaultAsync(m => m.AttractionID == id);
            if (aTTRACTION == null)
            {
                return NotFound();
            }

            return View(aTTRACTION);
        }

        // GET: ATTRACTIONs/Create
        [Authorize(Roles =("Admin"))]
        public IActionResult Create()
        {
            return View();
        }

        // POST: ATTRACTIONs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize(Roles = ("Admin"))]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("AttractionID,AttractionName,Capacity,Open_Time,Close_Time,Last_Maintained,Height_Req_Inches,Age_Req")] ATTRACTION aTTRACTION)
        {
            if (ModelState.IsValid)
            {
                _context.Add(aTTRACTION);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(aTTRACTION);
        }

        // GET: ATTRACTIONs/Edit/5
        [Authorize(Roles = ("Admin"))]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.ATTRACTION == null)
            {
                return NotFound();
            }

            var aTTRACTION = await _context.ATTRACTION.FindAsync(id);
            if (aTTRACTION == null)
            {
                return NotFound();
            }
            return View(aTTRACTION);
        }

        // POST: ATTRACTIONs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize(Roles = ("Admin"))]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("AttractionID,AttractionName,Capacity,Open_Time,Close_Time,Last_Maintained,Height_Req_Inches,Age_Req")] ATTRACTION aTTRACTION)
        {
            if (id != aTTRACTION.AttractionID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(aTTRACTION);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ATTRACTIONExists(aTTRACTION.AttractionID))
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
            return View(aTTRACTION);
        }

        // GET: ATTRACTIONs/Delete/5
        [Authorize(Roles = ("Admin"))]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.ATTRACTION == null)
            {
                return NotFound();
            }

            var aTTRACTION = await _context.ATTRACTION
                .FirstOrDefaultAsync(m => m.AttractionID == id);
            if (aTTRACTION == null)
            {
                return NotFound();
            }

            return View(aTTRACTION);
        }

        // POST: ATTRACTIONs/Delete/5
        [Authorize(Roles = ("Admin"))]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.ATTRACTION == null)
            {
                return Problem("Entity set 'AdventureLandWebappContext.ATTRACTION'  is null.");
            }
            var aTTRACTION = await _context.ATTRACTION.FindAsync(id);
            if (aTTRACTION != null)
            {
                _context.ATTRACTION.Remove(aTTRACTION);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ATTRACTIONExists(int id)
        {
          return (_context.ATTRACTION?.Any(e => e.AttractionID == id)).GetValueOrDefault();
        }
    }
}
