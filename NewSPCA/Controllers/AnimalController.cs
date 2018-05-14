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
    public class AnimalController : Controller
    {
        private readonly AnimalContext _context;

        public AnimalController(AnimalContext context)
        {
            _context = context;
        }

        // GET: Animal
        public async Task<IActionResult> Index()
        {
            var animalContext = _context.Animals.Include(a => a.Breed).Include(a => a.Site).Include(a => a.Species);
            return View(await animalContext.ToListAsync());
        }

        // GET: Animal/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var animal = await _context.Animals
                .Include(a => a.Breed)
                .Include(a => a.Site)
                .Include(a => a.Species)
                .SingleOrDefaultAsync(m => m.ID == id);
            if (animal == null)
            {
                return NotFound();
            }

            return View(animal);
        }

        // GET: Animal/Create
        public IActionResult Create()
        {
            ViewData["BreedID"] = new SelectList(_context.Breeds, "BreedID", "Breed_Name");
            ViewData["SiteID"] = new SelectList(_context.Sites, "SiteID", "Site_Name");
            ViewData["SpeciesID"] = new SelectList(_context.Species, "SpeciesID", "Species_Name");
            return View();
        }

        // POST: Animal/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Name,Age,Gender,Size,Color,Intake_Date,Price,Declawed,Housebroken,Spayed_Neutered,SpeciesID,BreedID,SiteID")] Animal animal)
        {
            if (ModelState.IsValid)
            {
                _context.Add(animal);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["BreedID"] = new SelectList(_context.Breeds, "BreedID", "Breed_Name", animal.BreedID);
            ViewData["SiteID"] = new SelectList(_context.Sites, "SiteID", "Site_Name", animal.SiteID);
            ViewData["SpeciesID"] = new SelectList(_context.Species, "SpeciesID", "Species_Name", animal.SpeciesID);
            return View(animal);
        }

        // GET: Animal/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var animal = await _context.Animals.SingleOrDefaultAsync(m => m.ID == id);
            if (animal == null)
            {
                return NotFound();
            }
            ViewData["BreedID"] = new SelectList(_context.Breeds, "BreedID", "Breed_Name", animal.BreedID);
            ViewData["SiteID"] = new SelectList(_context.Sites, "SiteID", "Site_Name", animal.SiteID);
            ViewData["SpeciesID"] = new SelectList(_context.Species, "SpeciesID", "Species_Name", animal.SpeciesID);
            return View(animal);
        }

        // POST: Animal/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Name,Age,Gender,Size,Color,Intake_Date,Price,Declawed,Housebroken,Spayed_Neutered,SpeciesID,BreedID,SiteID")] Animal animal)
        {
            if (id != animal.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(animal);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AnimalExists(animal.ID))
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
            ViewData["BreedID"] = new SelectList(_context.Breeds, "BreedID", "Breed_Name", animal.BreedID);
            ViewData["SiteID"] = new SelectList(_context.Sites, "SiteID", "Site_Name", animal.SiteID);
            ViewData["SpeciesID"] = new SelectList(_context.Species, "SpeciesID", "Species_Name", animal.SpeciesID);
            return View(animal);
        }

        // GET: Animal/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var animal = await _context.Animals
                .Include(a => a.Breed)
                .Include(a => a.Site)
                .Include(a => a.Species)
                .SingleOrDefaultAsync(m => m.ID == id);
            if (animal == null)
            {
                return NotFound();
            }

            return View(animal);
        }

        // POST: Animal/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var animal = await _context.Animals.SingleOrDefaultAsync(m => m.ID == id);
            _context.Animals.Remove(animal);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AnimalExists(int id)
        {
            return _context.Animals.Any(e => e.ID == id);
        }
    }
}
