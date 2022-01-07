using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
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
    public class FAQsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IWebHostEnvironment _hostEnvironment;

        public FAQsController(ApplicationDbContext context, IWebHostEnvironment hostEnvironment)
        {
            _context = context;
            this._hostEnvironment = hostEnvironment;
        }

        // GET: Admin/FAQs
        public async Task<IActionResult> Index()
        {
            return View(await _context.FAQ.ToListAsync());
        }

        // GET: Admin/FAQs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var fAQ = await _context.FAQ
                .FirstOrDefaultAsync(m => m.ID == id);
            if (fAQ == null)
            {
                return NotFound();
            }

            return View(fAQ);
        }

        // GET: Admin/FAQs/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Admin/FAQs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Faq_Heading,Faq_Text,IsActive")] FAQ fAQ)
        {
            if (ModelState.IsValid)
            {
                _context.Add(fAQ);
                await _context.SaveChangesAsync();
                TempData["message"] = "Saved";
                return RedirectToAction(nameof(Index));
            }
            return View(fAQ);
        }

        // GET: Admin/FAQs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var fAQ = await _context.FAQ.FindAsync(id);
           

            if (fAQ == null)
            {
                return NotFound();
            }
            return View(fAQ);
        }

        // POST: Admin/FAQs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, FAQ fAQ)
        {
            if (id != fAQ.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(fAQ);
                    TempData["message"] = "Updated";
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FAQExists(fAQ.ID))
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
            return View(fAQ);
        }

        // GET: Admin/FAQs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var fAQ = await _context.FAQ
                .FirstOrDefaultAsync(m => m.ID == id);
            if (fAQ == null)
            {
                return NotFound();
            }

            return View(fAQ);
        }

        // POST: Admin/FAQs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var fAQ = await _context.FAQ.FindAsync(id);
            _context.FAQ.Remove(fAQ);
            await _context.SaveChangesAsync();
            TempData["message"] = "Delete";
            return RedirectToAction(nameof(Index));
        }

        private bool FAQExists(int id)
        {
            return _context.FAQ.Any(e => e.ID == id);
        }
    }
}
