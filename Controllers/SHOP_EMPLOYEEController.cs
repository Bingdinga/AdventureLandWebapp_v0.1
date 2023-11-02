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
    public class SHOP_EMPLOYEEController : Controller
    {
        private readonly AdventureLandWebappContext _context;

        public SHOP_EMPLOYEEController(AdventureLandWebappContext context)
        {
            _context = context;
        }

        // GET: SHOP_EMPLOYEE
        public async Task<IActionResult> Index()
        {
              return _context.SHOP_EMPLOYEE != null ? 
                          View(await _context.SHOP_EMPLOYEE.ToListAsync()) :
                          Problem("Entity set 'AdventureLandWebappContext.SHOP_EMPLOYEE'  is null.");
        }

        // GET: SHOP_EMPLOYEE/Details/5
        [Authorize]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.SHOP_EMPLOYEE == null)
            {
                return NotFound();
            }

            var sHOP_EMPLOYEE = await _context.SHOP_EMPLOYEE
                .FirstOrDefaultAsync(m => m.Id == id);
            if (sHOP_EMPLOYEE == null)
            {
                return NotFound();
            }

            return View(sHOP_EMPLOYEE);
        }

        // GET: SHOP_EMPLOYEE/Create
        [Authorize]
        public IActionResult Create()
        {
            return View();
        }

        // POST: SHOP_EMPLOYEE/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,ShopID")] SHOP_EMPLOYEE sHOP_EMPLOYEE)
        {
            if (ModelState.IsValid)
            {
                _context.Add(sHOP_EMPLOYEE);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(sHOP_EMPLOYEE);
        }

        // GET: SHOP_EMPLOYEE/Edit/5
        [Authorize]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.SHOP_EMPLOYEE == null)
            {
                return NotFound();
            }

            var sHOP_EMPLOYEE = await _context.SHOP_EMPLOYEE.FindAsync(id);
            if (sHOP_EMPLOYEE == null)
            {
                return NotFound();
            }
            return View(sHOP_EMPLOYEE);
        }

        // POST: SHOP_EMPLOYEE/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,ShopID")] SHOP_EMPLOYEE sHOP_EMPLOYEE)
        {
            if (id != sHOP_EMPLOYEE.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(sHOP_EMPLOYEE);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SHOP_EMPLOYEEExists(sHOP_EMPLOYEE.Id))
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
            return View(sHOP_EMPLOYEE);
        }

        // GET: SHOP_EMPLOYEE/Delete/5
        [Authorize]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.SHOP_EMPLOYEE == null)
            {
                return NotFound();
            }

            var sHOP_EMPLOYEE = await _context.SHOP_EMPLOYEE
                .FirstOrDefaultAsync(m => m.Id == id);
            if (sHOP_EMPLOYEE == null)
            {
                return NotFound();
            }

            return View(sHOP_EMPLOYEE);
        }

        // POST: SHOP_EMPLOYEE/Delete/5
        [Authorize]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.SHOP_EMPLOYEE == null)
            {
                return Problem("Entity set 'AdventureLandWebappContext.SHOP_EMPLOYEE'  is null.");
            }
            var sHOP_EMPLOYEE = await _context.SHOP_EMPLOYEE.FindAsync(id);
            if (sHOP_EMPLOYEE != null)
            {
                _context.SHOP_EMPLOYEE.Remove(sHOP_EMPLOYEE);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SHOP_EMPLOYEEExists(int id)
        {
          return (_context.SHOP_EMPLOYEE?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
