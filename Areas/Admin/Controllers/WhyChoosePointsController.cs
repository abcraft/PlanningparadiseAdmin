using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PlanningParadiseAdmin.Data;
using PlanningParadiseAdmin.Models;

namespace PlanningParadiseAdmin.Areas.Admin.Controllers
{
    [Authorize]
    [Area("Admin")]
    public class WhyChoosePointsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public WhyChoosePointsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Admin/WhyChoosePoints
        public async Task<IActionResult> Index()
        {
            return View(await _context.WhyChoosePoints.ToListAsync());
        }

        // GET: Admin/WhyChoosePoints/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var whyChoosePoints = await _context.WhyChoosePoints
                .FirstOrDefaultAsync(m => m.Id == id);
            if (whyChoosePoints == null)
            {
                return NotFound();
            }

            return View(whyChoosePoints);
        }

        // GET: Admin/WhyChoosePoints/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Admin/WhyChoosePoints/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,PointText")] WhyChoosePoints whyChoosePoints)
        {
            if (ModelState.IsValid)
            {
                _context.Add(whyChoosePoints);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(whyChoosePoints);
        }

        // GET: Admin/WhyChoosePoints/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var whyChoosePoints = await _context.WhyChoosePoints.FindAsync(id);
            if (whyChoosePoints == null)
            {
                return NotFound();
            }
            return View(whyChoosePoints);
        }

        // POST: Admin/WhyChoosePoints/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,PointText")] WhyChoosePoints whyChoosePoints)
        {
            if (id != whyChoosePoints.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(whyChoosePoints);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!WhyChoosePointsExists(whyChoosePoints.Id))
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
            return View(whyChoosePoints);
        }

        // GET: Admin/WhyChoosePoints/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var whyChoosePoints = await _context.WhyChoosePoints
                .FirstOrDefaultAsync(m => m.Id == id);
            if (whyChoosePoints == null)
            {
                return NotFound();
            }

            return View(whyChoosePoints);
        }

        // POST: Admin/WhyChoosePoints/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var whyChoosePoints = await _context.WhyChoosePoints.FindAsync(id);
            _context.WhyChoosePoints.Remove(whyChoosePoints);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool WhyChoosePointsExists(int id)
        {
            return _context.WhyChoosePoints.Any(e => e.Id == id);
        }
    }
}
