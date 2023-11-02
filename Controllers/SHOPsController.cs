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
    public class SHOPsController : Controller
    {
        private readonly AdventureLandWebappContext _context;

        public SHOPsController(AdventureLandWebappContext context)
        {
            _context = context;
        }

        // GET: SHOPs
        public async Task<IActionResult> Index()
        {
              return _context.SHOP != null ? 
                          View(await _context.SHOP.ToListAsync()) :
                          Problem("Entity set 'AdventureLandWebappContext.SHOP'  is null.");
        }

        // GET: SHOPs/Details/5
        [Authorize]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.SHOP == null)
            {
                return NotFound();
            }

            var sHOP = await _context.SHOP
                .FirstOrDefaultAsync(m => m.ShopID == id);
            if (sHOP == null)
            {
                return NotFound();
            }

            return View(sHOP);
        }

        // GET: SHOPs/Create
        [Authorize]
        public IActionResult Create()
        {
            return View();
        }

        // POST: SHOPs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ShopID,ShopName,Location,Phone_Number")] SHOP sHOP)
        {
            if (ModelState.IsValid)
            {
                _context.Add(sHOP);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(sHOP);
        }

        // GET: SHOPs/Edit/5
        [Authorize]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.SHOP == null)
            {
                return NotFound();
            }

            var sHOP = await _context.SHOP.FindAsync(id);
            if (sHOP == null)
            {
                return NotFound();
            }
            return View(sHOP);
        }

        // POST: SHOPs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ShopID,ShopName,Location,Phone_Number")] SHOP sHOP)
        {
            if (id != sHOP.ShopID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(sHOP);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SHOPExists(sHOP.ShopID))
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
            return View(sHOP);
        }

        // GET: SHOPs/Delete/5
        [Authorize]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.SHOP == null)
            {
                return NotFound();
            }

            var sHOP = await _context.SHOP
                .FirstOrDefaultAsync(m => m.ShopID == id);
            if (sHOP == null)
            {
                return NotFound();
            }

            return View(sHOP);
        }

        // POST: SHOPs/Delete/5
        [Authorize]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.SHOP == null)
            {
                return Problem("Entity set 'AdventureLandWebappContext.SHOP'  is null.");
            }
            var sHOP = await _context.SHOP.FindAsync(id);
            if (sHOP != null)
            {
                _context.SHOP.Remove(sHOP);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SHOPExists(int id)
        {
          return (_context.SHOP?.Any(e => e.ShopID == id)).GetValueOrDefault();
        }
    }
}
