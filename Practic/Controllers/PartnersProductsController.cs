using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Practic.Models;

namespace Practic.Controllers
{
    public class PartnersProductsController : Controller
    {
        private readonly AppDbContext _context;

        public PartnersProductsController(AppDbContext context)
        {
            _context = context;
        }

        // GET: PartnersProducts
        public async Task<IActionResult> Index()
        {
            var appDbContext = _context.PartnersProducts.Include(p => p.Partner).Include(p => p.Product);
            return View(await appDbContext.ToListAsync());
        }

        // GET: PartnersProducts/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var partnersProducts = await _context.PartnersProducts
                .Include(p => p.Partner)
                .Include(p => p.Product)
                .Where(p => p.PartnerId == id).ToListAsync();

            if (partnersProducts == null)
            {
                return NotFound();
            }

            return View(partnersProducts);
        }

        // GET: PartnersProducts/Create
        public IActionResult Create()
        {
            ViewData["PartnerId"] = new SelectList(_context.Partners, "Id", "Id");
            ViewData["ProductId"] = new SelectList(_context.Products, "Id", "Id");
            return View();
        }

        // POST: PartnersProducts/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,ProductId,PartnerId,Quantity,SaleDate")] PartnersProduct partnersProduct)
        {
            if (ModelState.IsValid)
            {
                _context.Add(partnersProduct);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["PartnerId"] = new SelectList(_context.Partners, "Id", "Id", partnersProduct.PartnerId);
            ViewData["ProductId"] = new SelectList(_context.Products, "Id", "Id", partnersProduct.ProductId);
            return View(partnersProduct);
        }

        // GET: PartnersProducts/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var partnersProduct = await _context.PartnersProducts.FindAsync(id);
            if (partnersProduct == null)
            {
                return NotFound();
            }
            ViewData["PartnerId"] = new SelectList(_context.Partners, "Id", "Id", partnersProduct.PartnerId);
            ViewData["ProductId"] = new SelectList(_context.Products, "Id", "Id", partnersProduct.ProductId);
            return View(partnersProduct);
        }

        // POST: PartnersProducts/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,ProductId,PartnerId,Quantity,SaleDate")] PartnersProduct partnersProduct)
        {
            if (id != partnersProduct.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(partnersProduct);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PartnersProductExists(partnersProduct.Id))
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
            ViewData["PartnerId"] = new SelectList(_context.Partners, "Id", "Id", partnersProduct.PartnerId);
            ViewData["ProductId"] = new SelectList(_context.Products, "Id", "Id", partnersProduct.ProductId);
            return View(partnersProduct);
        }

        // GET: PartnersProducts/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var partnersProduct = await _context.PartnersProducts
                .Include(p => p.Partner)
                .Include(p => p.Product)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (partnersProduct == null)
            {
                return NotFound();
            }

            return View(partnersProduct);
        }

        // POST: PartnersProducts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var partnersProduct = await _context.PartnersProducts.FindAsync(id);
            if (partnersProduct != null)
            {
                _context.PartnersProducts.Remove(partnersProduct);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PartnersProductExists(int id)
        {
            return _context.PartnersProducts.Any(e => e.Id == id);
        }
    }
}
