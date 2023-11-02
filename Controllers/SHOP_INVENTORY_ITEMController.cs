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
    public class SHOP_INVENTORY_ITEMController : Controller
    {
        private readonly AdventureLandWebappContext _context;

        public SHOP_INVENTORY_ITEMController(AdventureLandWebappContext context)
        {
            _context = context;
        }

        // GET: SHOP_INVENTORY_ITEM
        public async Task<IActionResult> Index()
        {
              return _context.SHOP_INVENTORY_ITEM != null ? 
                          View(await _context.SHOP_INVENTORY_ITEM.ToListAsync()) :
                          Problem("Entity set 'AdventureLandWebappContext.SHOP_INVENTORY_ITEM'  is null.");
        }

        // GET: SHOP_INVENTORY_ITEM/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.SHOP_INVENTORY_ITEM == null)
            {
                return NotFound();
            }

            var sHOP_INVENTORY_ITEM = await _context.SHOP_INVENTORY_ITEM
                .FirstOrDefaultAsync(m => m.Id == id);
            if (sHOP_INVENTORY_ITEM == null)
            {
                return NotFound();
            }

            return View(sHOP_INVENTORY_ITEM);
        }

        // GET: SHOP_INVENTORY_ITEM/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: SHOP_INVENTORY_ITEM/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,ShopID,Stocked_On,Sold_On")] SHOP_INVENTORY_ITEM sHOP_INVENTORY_ITEM)
        {
            if (ModelState.IsValid)
            {
                _context.Add(sHOP_INVENTORY_ITEM);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(sHOP_INVENTORY_ITEM);
        }

        // GET: SHOP_INVENTORY_ITEM/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.SHOP_INVENTORY_ITEM == null)
            {
                return NotFound();
            }

            var sHOP_INVENTORY_ITEM = await _context.SHOP_INVENTORY_ITEM.FindAsync(id);
            if (sHOP_INVENTORY_ITEM == null)
            {
                return NotFound();
            }
            return View(sHOP_INVENTORY_ITEM);
        }

        // POST: SHOP_INVENTORY_ITEM/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,ShopID,Stocked_On,Sold_On")] SHOP_INVENTORY_ITEM sHOP_INVENTORY_ITEM)
        {
            if (id != sHOP_INVENTORY_ITEM.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(sHOP_INVENTORY_ITEM);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SHOP_INVENTORY_ITEMExists(sHOP_INVENTORY_ITEM.Id))
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
            return View(sHOP_INVENTORY_ITEM);
        }

        // GET: SHOP_INVENTORY_ITEM/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.SHOP_INVENTORY_ITEM == null)
            {
                return NotFound();
            }

            var sHOP_INVENTORY_ITEM = await _context.SHOP_INVENTORY_ITEM
                .FirstOrDefaultAsync(m => m.Id == id);
            if (sHOP_INVENTORY_ITEM == null)
            {
                return NotFound();
            }

            return View(sHOP_INVENTORY_ITEM);
        }

        // POST: SHOP_INVENTORY_ITEM/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.SHOP_INVENTORY_ITEM == null)
            {
                return Problem("Entity set 'AdventureLandWebappContext.SHOP_INVENTORY_ITEM'  is null.");
            }
            var sHOP_INVENTORY_ITEM = await _context.SHOP_INVENTORY_ITEM.FindAsync(id);
            if (sHOP_INVENTORY_ITEM != null)
            {
                _context.SHOP_INVENTORY_ITEM.Remove(sHOP_INVENTORY_ITEM);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SHOP_INVENTORY_ITEMExists(int id)
        {
          return (_context.SHOP_INVENTORY_ITEM?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
