using GraduateAppTracker.Data;
using GraduateAppTracker.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GraduateAppTracker.Controllers
{
    public class ApplicationsController : Controller
    {
        private readonly AppDbContext _context;

        public ApplicationsController(AppDbContext context)
        {
            _context = context;
        }

        // GET: Applications/Create
        public IActionResult Create()
        {
            return View(new UniversityProgram { ApplicationDate = DateTime.Today.AddDays(30) });
        }

        // POST: Applications/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(UniversityProgram program)
        {
            // If language not required, clear the language score
            if (!program.RequiresLanguage)
            {
                program.MinLanguageScore = null;
                ModelState.Remove("MinLanguageScore");
            }

            if (ModelState.IsValid)
            {
                program.CreatedAt = DateTime.Now;
                _context.Add(program);
                await _context.SaveChangesAsync();
                TempData["SuccessMessage"] = $"✓ '{program.UniversityName} - {program.DepartmentName}' ilanı başarıyla eklendi!";
                return RedirectToAction(nameof(Index), "Home");
            }

            return View(program);
        }

        // GET: Applications/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return NotFound();

            var program = await _context.UniversityPrograms.FindAsync(id);
            if (program == null) return NotFound();

            return View(program);
        }

        // POST: Applications/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, UniversityProgram program)
        {
            if (id != program.Id) return NotFound();

            if (!program.RequiresLanguage)
            {
                program.MinLanguageScore = null;
                ModelState.Remove("MinLanguageScore");
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(program);
                    await _context.SaveChangesAsync();
                    TempData["SuccessMessage"] = $"✓ '{program.UniversityName} - {program.DepartmentName}' ilanı güncellendi.";
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!_context.UniversityPrograms.Any(e => e.Id == program.Id))
                        return NotFound();
                    throw;
                }
                return RedirectToAction(nameof(Index), "Home");
            }

            return View(program);
        }

        // GET: Applications/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();

            var program = await _context.UniversityPrograms.FirstOrDefaultAsync(m => m.Id == id);
            if (program == null) return NotFound();

            return View(program);
        }

        // POST: Applications/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var program = await _context.UniversityPrograms.FindAsync(id);
            if (program != null)
            {
                _context.UniversityPrograms.Remove(program);
                await _context.SaveChangesAsync();
                TempData["SuccessMessage"] = "İlan başarıyla silindi.";
            }
            return RedirectToAction(nameof(Index), "Home");
        }

        // GET: Applications/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null) return NotFound();

            var program = await _context.UniversityPrograms.FirstOrDefaultAsync(m => m.Id == id);
            if (program == null) return NotFound();

            return View(program);
        }
    }
}
