using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Practic.Models;

namespace Practic.Controllers
{
    [Authorize]
    public class PartnersController : Controller
    {
        private readonly AppDbContext _context;

        public PartnersController(AppDbContext context)
        {
            _context = context;
        }

        // GET: Partners1
        public async Task<IActionResult> Index()
        {
            try
            {
                return View(await _context.Partners.Include(p => p.PartnersProducts).Include(p => p.TypeNavigation).ToListAsync());
            }
            catch (Exception)
            {
                return StatusCode(500, new { error="недоступен сервер"});
            }
        }

        // GET: Partners1/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            try
            {
                Console.WriteLine($"{id}");
                return RedirectToAction($"Details", "PartnersProducts");
                if (id == null)
                {
                    return NotFound();
                }

                var partner = await _context.Partners
                    .Include(p => p.PartnersProducts)
                    .Include(p => p.TypeNavigation)
                    .FirstOrDefaultAsync(m => m.Id == id);
                if (partner == null)
                {
                    return NotFound();
                }

                return View(partner);
            }
            catch (Exception)
            {
                return StatusCode(500, new { error = "недоступен сервер" });
            }
            
        }

        // GET: Partners1/Create
        public IActionResult Create()
        {
            try
            {

                ViewData["Type"] = new SelectList(_context.PartenersTypes, "Id", "Title");
                return View();
            }
            catch (Exception)
            {
                return StatusCode(500, new { error = "недоступен сервер" });
            }
        }

        // POST: Partners1/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Type,Title,Director,Email,Phone,Address,Inn,Rating")] Partner partner)
        {
            try
            {
               // if (ModelState.IsValid)
                {
                    _context.Add(partner);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                ViewData["Type"] = new SelectList(_context.PartenersTypes, "Id", "Id", partner.Type);
                return View(partner);
            }
            catch (Exception)
            {
                return StatusCode(500, new { error = "недоступен сервер" });
            }
        }

        // GET: Partners1/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            try
            {
                if (id == null)
                {
                    return NotFound();
                }

                var partner = await _context.Partners.FindAsync(id);
                if (partner == null)
                {
                    return NotFound();
                }
                ViewData["Type"] = new SelectList(_context.PartenersTypes, "Id", "Title");
                return View(partner);
            }
            catch (Exception)
            {
                return StatusCode(500, new { error = "недоступен сервер" });
            }

        }

        // POST: Partners1/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Type,Title,Director,Email,Phone,Address,Inn,Rating")] Partner partner)
        {
            try
            {
                if (id != partner.Id)
                {
                    return NotFound();
                }

                if (ModelState.IsValid)
                {
                    try
                    {
                        _context.Update(partner);
                        await _context.SaveChangesAsync();
                    }
                    catch (DbUpdateConcurrencyException)
                    {
                        if (!PartnerExists(partner.Id))
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
                ViewData["Type"] = new SelectList(_context.PartenersTypes, "Id", "Id", partner.Type);
                return View(partner);
            }
            catch (Exception)
            {
                return StatusCode(500, new { error = "недоступен сервер" });
            }

        }

        // GET: Partners1/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var partner = await _context.Partners
                .Include(p => p.TypeNavigation)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (partner == null)
            {
                return NotFound();
            }

            return View(partner);
        }

        // POST: Partners1/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var partner = await _context.Partners.FindAsync(id);
            if (partner != null)
            {
                _context.Partners.Remove(partner);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PartnerExists(int id)
        {
            return _context.Partners.Any(e => e.Id == id);
        }
    }
}
