using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using NewSPCA.Data;
using NewSPCA.Models;

namespace NewSPCA.Controllers
{
    public class SiteController : Controller
    {
        private readonly AnimalContext _context;

        public SiteController(AnimalContext context)
        {
            _context = context;
        }

        // GET: Site
        public async Task<IActionResult> Index()
        {
            return View(await _context.Sites.ToListAsync());
        }

        // GET: Site/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var site = await _context.Sites
                .SingleOrDefaultAsync(m => m.SiteID == id);
            if (site == null)
            {
                return NotFound();
            }

            return View(site);
        }

        // GET: Site/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Site/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("SiteID,Site_Name,Site_Address,City,PostalCode,Province")] Site site)
        {
            if (ModelState.IsValid)
            {
                _context.Add(site);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(site);
        }

        // GET: Site/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var site = await _context.Sites.SingleOrDefaultAsync(m => m.SiteID == id);
            if (site == null)
            {
                return NotFound();
            }
            return View(site);
        }

        // POST: Site/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("SiteID,Site_Name,Site_Address,City,PostalCode,Province")] Site site)
        {
            if (id != site.SiteID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(site);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SiteExists(site.SiteID))
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
            return View(site);
        }

        // GET: Site/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var site = await _context.Sites
                .SingleOrDefaultAsync(m => m.SiteID == id);
            if (site == null)
            {
                return NotFound();
            }

            return View(site);
        }

        // POST: Site/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var site = await _context.Sites.SingleOrDefaultAsync(m => m.SiteID == id);
            _context.Sites.Remove(site);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SiteExists(int id)
        {
            return _context.Sites.Any(e => e.SiteID == id);
        }
    }
}
