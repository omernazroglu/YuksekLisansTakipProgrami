using GraduateAppTracker.Data;
using GraduateAppTracker.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GraduateAppTracker.Controllers
{
    public class HomeController : Controller
    {
        private readonly AppDbContext _context;

        public HomeController(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index(string? search, string? filter)
        {
            var query = _context.UniversityPrograms.AsQueryable();

            // Search filter
            if (!string.IsNullOrWhiteSpace(search))
            {
                query = query.Where(p =>
                    p.UniversityName.Contains(search) ||
                    p.DepartmentName.Contains(search));
            }

            // Status filter
            if (filter == "active")
                query = query.Where(p => p.ApplicationDate >= DateTime.Today);
            else if (filter == "expired")
                query = query.Where(p => p.ApplicationDate < DateTime.Today);
            else if (filter == "urgent")
                query = query.Where(p => p.ApplicationDate >= DateTime.Today && p.ApplicationDate <= DateTime.Today.AddDays(7));

            var programs = await query
                .OrderBy(p => p.ApplicationDate)
                .ToListAsync();

            // Statistics
            var all = await _context.UniversityPrograms.ToListAsync();
            ViewBag.TotalCount = all.Count;
            ViewBag.ActiveCount = all.Count(p => p.ApplicationDate >= DateTime.Today);
            ViewBag.UrgentCount = all.Count(p => p.ApplicationDate >= DateTime.Today && p.ApplicationDate <= DateTime.Today.AddDays(7));
            ViewBag.ExpiredCount = all.Count(p => p.ApplicationDate < DateTime.Today);

            ViewBag.SearchTerm = search;
            ViewBag.ActiveFilter = filter;

            return View(programs);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View();
        }
    }
}
