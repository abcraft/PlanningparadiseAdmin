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
using PlanningParadiseAdmin.ViewModel;

namespace PlanningParadiseAdmin.Areas.Admin.Controllers
{
    [Authorize]
    [Area("Admin")]
    public class WhyChoosUsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public WhyChoosUsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Admin/WhyChoosUs
        public async Task<IActionResult> Index()
        {
            return View(await _context.WhyChoosUs.ToListAsync());
        }

        // GET: Admin/WhyChoosUs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var whyChoosUs = await _context.WhyChoosUs
                .FirstOrDefaultAsync(m => m.ID == id);
            if (whyChoosUs == null)
            {
                return NotFound();
            }

            return View(whyChoosUs);
        }

        // GET: Admin/WhyChoosUs/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Admin/WhyChoosUs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,WhyUS_Heading,WhyUs_Text,IsActive")] WhyChoosUs whyChoosUs)
        {
            if (ModelState.IsValid)
            {
                _context.Add(whyChoosUs);
                await _context.SaveChangesAsync();
                TempData["message"] = "Saved";
                return RedirectToAction(nameof(Index));
            }
            return View(whyChoosUs);
        }

        // GET: Admin/WhyChoosUs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var whyChoosUs = await _context.WhyChoosUs.FindAsync(id);
            WhyChooseUsVM wvm = new WhyChooseUsVM();
            wvm.ID = whyChoosUs.ID;
            wvm.WhyUS_Heading = whyChoosUs.WhyUS_Heading;
            wvm.WhyUs_Text = whyChoosUs.WhyUs_Text;
            wvm.IsActive = whyChoosUs.IsActive;

            if (whyChoosUs == null)
            {
                return NotFound();
            }
            return View(wvm);
        }

        // POST: Admin/WhyChoosUs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, WhyChooseUsVM wvm)
        {
            if (id != wvm.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    WhyChoosUs whyChoos = new WhyChoosUs();
                    whyChoos.ID = wvm.ID;
                    whyChoos.WhyUS_Heading = wvm.WhyUS_Heading;
                    whyChoos.WhyUs_Text = wvm.WhyUs_Text;
                    whyChoos.IsActive = wvm.IsActive;
                    _context.Update(whyChoos);
                    TempData["message"] = "Updated";
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!WhyChoosUsExists(wvm.ID))
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
            return View(wvm);
        }

        // GET: Admin/WhyChoosUs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var whyChoosUs = await _context.WhyChoosUs
                .FirstOrDefaultAsync(m => m.ID == id);
            if (whyChoosUs == null)
            {
                return NotFound();
            }

            return View(whyChoosUs);
        }

        // POST: Admin/WhyChoosUs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var whyChoosUs = await _context.WhyChoosUs.FindAsync(id);
            _context.WhyChoosUs.Remove(whyChoosUs);
            await _context.SaveChangesAsync();
            TempData["message"] = "Delete";
            return RedirectToAction(nameof(Index));
        }

        private bool WhyChoosUsExists(int id)
        {
            return _context.WhyChoosUs.Any(e => e.ID == id);
        }
    }
}
