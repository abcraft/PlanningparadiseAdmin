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
    public class TestimonialsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public TestimonialsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Admin/Testimonials
        public async Task<IActionResult> Index()
        {
            return View(await _context.Testimonials.ToListAsync());
        }

        // GET: Admin/Testimonials/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var testimonial = await _context.Testimonials
                .FirstOrDefaultAsync(m => m.ID == id);
            if (testimonial == null)
            {
                return NotFound();
            }

            return View(testimonial);
        }

        // GET: Admin/Testimonials/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Admin/Testimonials/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Testimonial_Img,Testimonial_Name,Testimonial_Text,Testimonial_Order,IsAvtive")] Testimonial testimonial)
        {
            if (ModelState.IsValid)
            {
                _context.Add(testimonial);
                await _context.SaveChangesAsync();
                TempData["message"] = "Saved";
                return RedirectToAction(nameof(Index));
            }
            return View(testimonial);
        }

        // GET: Admin/Testimonials/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var testimonial = await _context.Testimonials.FindAsync(id);
            TestimonialVM tvm = new TestimonialVM();
            tvm.ID = testimonial.ID;
            tvm.Testimonial_Name = testimonial.Testimonial_Name;
            tvm.Testimonial_Text = testimonial.Testimonial_Text;
            tvm.Testimonial_Order = testimonial.Testimonial_Order;
            tvm.IsAvtive = testimonial.IsAvtive;

            if (testimonial == null)
            {
                return NotFound();
            }
            return View(tvm);
        }

        // POST: Admin/Testimonials/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, TestimonialVM tvm)
        {
            if (id != tvm.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    Testimonial testimonial = new Testimonial();
                    testimonial.ID = tvm.ID;
                    testimonial.Testimonial_Name = tvm.Testimonial_Name;
                    testimonial.Testimonial_Text = tvm.Testimonial_Text;
                    testimonial.Testimonial_Order = tvm.Testimonial_Order;
                    testimonial.IsAvtive = tvm.IsAvtive;
                    _context.Update(testimonial);
                    TempData["message"] = "Updated";
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TestimonialExists(tvm.ID))
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
            return View();
        }

        // GET: Admin/Testimonials/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var testimonial = await _context.Testimonials
                .FirstOrDefaultAsync(m => m.ID == id);
            if (testimonial == null)
            {
                return NotFound();
            }

            return View(testimonial);
        }

        // POST: Admin/Testimonials/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var testimonial = await _context.Testimonials.FindAsync(id);
            _context.Testimonials.Remove(testimonial);
            await _context.SaveChangesAsync();
            TempData["message"] = "Delete";
            return RedirectToAction(nameof(Index));
        }

        private bool TestimonialExists(int id)
        {
            return _context.Testimonials.Any(e => e.ID == id);
        }
    }
}
