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
    public class BuyersController : Controller
    {
        private readonly Liquor_ShopContext _context;

        public BuyersController(Liquor_ShopContext context)
        {
            _context = context;
        }

        // GET: Buyers
        public async Task<IActionResult> Index()
        {
            var liquor_ShopContext = _context.Buyer.Include(b => b.Seller_ID);
            return View(await liquor_ShopContext.ToListAsync());
        }

        // GET: Buyers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var buyer = await _context.Buyer
                .Include(b => b.Seller_ID)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (buyer == null)
            {
                return NotFound();
            }

            return View(buyer);
        }

        // GET: Buyers/Create
        public IActionResult Create()
        {
            ViewData["SellerID"] = new SelectList(_context.Seller, "Id", "Id");
            return View();
        }

        // POST: Buyers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Buyer_Name,Buyer_Address,Buyer_Contact,SellerID")] Buyer buyer)
        {
            if (ModelState.IsValid)
            {
                _context.Add(buyer);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["SellerID"] = new SelectList(_context.Seller, "Id", "Id", buyer.SellerID);
            return View(buyer);
        }

        // GET: Buyers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var buyer = await _context.Buyer.FindAsync(id);
            if (buyer == null)
            {
                return NotFound();
            }
            ViewData["SellerID"] = new SelectList(_context.Seller, "Id", "Id", buyer.SellerID);
            return View(buyer);
        }

        // POST: Buyers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Buyer_Name,Buyer_Address,Buyer_Contact,SellerID")] Buyer buyer)
        {
            if (id != buyer.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(buyer);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BuyerExists(buyer.Id))
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
            ViewData["SellerID"] = new SelectList(_context.Seller, "Id", "Id", buyer.SellerID);
            return View(buyer);
        }

        // GET: Buyers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var buyer = await _context.Buyer
                .Include(b => b.Seller_ID)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (buyer == null)
            {
                return NotFound();
            }

            return View(buyer);
        }

        // POST: Buyers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var buyer = await _context.Buyer.FindAsync(id);
            _context.Buyer.Remove(buyer);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BuyerExists(int id)
        {
            return _context.Buyer.Any(e => e.Id == id);
        }
    }
}
