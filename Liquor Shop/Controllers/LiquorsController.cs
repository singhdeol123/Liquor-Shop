using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Liquor_Shop.Data;
using Liquor_Shop.Models;

namespace Liquor_Shop.Controllers
{
    public class LiquorsController : Controller
    {
        private readonly Liquor_ShopContext _context;

        public LiquorsController(Liquor_ShopContext context)
        {
            _context = context;
        }

        // GET: Liquors
        public async Task<IActionResult> Index()
        {
            return View(await _context.Liquor.ToListAsync());
        }

        // GET: Liquors/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var liquor = await _context.Liquor
                .FirstOrDefaultAsync(m => m.Id == id);
            if (liquor == null)
            {
                return NotFound();
            }

            return View(liquor);
        }

        // GET: Liquors/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Liquors/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,LiquorStore_Name")] Liquor liquor)
        {
            if (ModelState.IsValid)
            {
                _context.Add(liquor);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(liquor);
        }

        // GET: Liquors/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var liquor = await _context.Liquor.FindAsync(id);
            if (liquor == null)
            {
                return NotFound();
            }
            return View(liquor);
        }

        // POST: Liquors/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,LiquorStore_Name")] Liquor liquor)
        {
            if (id != liquor.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(liquor);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LiquorExists(liquor.Id))
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
            return View(liquor);
        }

        // GET: Liquors/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var liquor = await _context.Liquor
                .FirstOrDefaultAsync(m => m.Id == id);
            if (liquor == null)
            {
                return NotFound();
            }

            return View(liquor);
        }

        // POST: Liquors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var liquor = await _context.Liquor.FindAsync(id);
            _context.Liquor.Remove(liquor);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LiquorExists(int id)
        {
            return _context.Liquor.Any(e => e.Id == id);
        }
    }
}
