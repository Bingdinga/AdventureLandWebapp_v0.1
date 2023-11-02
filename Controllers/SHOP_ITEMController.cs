using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AdventureLandWebapp.Data;
using AdventureLandWebapp.Models;

namespace AdventureLandWebapp.Controllers
{
    public class SHOP_ITEMController : Controller
    {
        private readonly AdventureLandWebappContext _context;

        public SHOP_ITEMController(AdventureLandWebappContext context)
        {
            _context = context;
        }

        // GET: SHOP_ITEM
        public async Task<IActionResult> Index()
        {
              return _context.SHOP_ITEM != null ? 
                          View(await _context.SHOP_ITEM.ToListAsync()) :
                          Problem("Entity set 'AdventureLandWebappContext.SHOP_ITEM'  is null.");
        }

        // GET: SHOP_ITEM/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.SHOP_ITEM == null)
            {
                return NotFound();
            }

            var sHOP_ITEM = await _context.SHOP_ITEM
                .FirstOrDefaultAsync(m => m.ID == id);
            if (sHOP_ITEM == null)
            {
                return NotFound();
            }

            return View(sHOP_ITEM);
        }

        // GET: SHOP_ITEM/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: SHOP_ITEM/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,ItemDesc,Sale_Price,Restock_Price")] SHOP_ITEM sHOP_ITEM)
        {
            if (ModelState.IsValid)
            {
                _context.Add(sHOP_ITEM);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(sHOP_ITEM);
        }

        // GET: SHOP_ITEM/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.SHOP_ITEM == null)
            {
                return NotFound();
            }

            var sHOP_ITEM = await _context.SHOP_ITEM.FindAsync(id);
            if (sHOP_ITEM == null)
            {
                return NotFound();
            }
            return View(sHOP_ITEM);
        }

        // POST: SHOP_ITEM/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,ItemDesc,Sale_Price,Restock_Price")] SHOP_ITEM sHOP_ITEM)
        {
            if (id != sHOP_ITEM.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(sHOP_ITEM);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SHOP_ITEMExists(sHOP_ITEM.ID))
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
            return View(sHOP_ITEM);
        }

        // GET: SHOP_ITEM/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.SHOP_ITEM == null)
            {
                return NotFound();
            }

            var sHOP_ITEM = await _context.SHOP_ITEM
                .FirstOrDefaultAsync(m => m.ID == id);
            if (sHOP_ITEM == null)
            {
                return NotFound();
            }

            return View(sHOP_ITEM);
        }

        // POST: SHOP_ITEM/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.SHOP_ITEM == null)
            {
                return Problem("Entity set 'AdventureLandWebappContext.SHOP_ITEM'  is null.");
            }
            var sHOP_ITEM = await _context.SHOP_ITEM.FindAsync(id);
            if (sHOP_ITEM != null)
            {
                _context.SHOP_ITEM.Remove(sHOP_ITEM);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SHOP_ITEMExists(int id)
        {
          return (_context.SHOP_ITEM?.Any(e => e.ID == id)).GetValueOrDefault();
        }
    }
}
