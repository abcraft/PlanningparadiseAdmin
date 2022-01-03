using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PlanningParadiseAdmin.Data;
using PlanningParadiseAdmin.Models;

namespace PlanningParadiseAdmin.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class DestinationWeddingsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IWebHostEnvironment _hostEnvironment;

        public DestinationWeddingsController(ApplicationDbContext context, IWebHostEnvironment hostEnvironment)
        {
            _context = context;
            this._hostEnvironment = hostEnvironment;
        }

        // GET: Admin/DestinationWeddings
        public async Task<IActionResult> Index()
        {
            return View(await _context.DestinationWedding.ToListAsync());
        }

        // GET: Admin/DestinationWeddings/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var destinationWedding = await _context.DestinationWedding
                .FirstOrDefaultAsync(m => m.ID == id);
            if (destinationWedding == null)
            {
                return NotFound();
            }

            return View(destinationWedding);
        }

        // GET: Admin/DestinationWeddings/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Admin/DestinationWeddings/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Destination_Img,Destination_Heading,IsNational,IsInterNational,IsActive")] DestinationWedding destinationWedding)
        {
            if (ModelState.IsValid)
            {
                if (HttpContext.Request.Form.Files.Count() > 0)
                {
                    var f = HttpContext.Request.Form.Files[0];
                    string wwwRootPath = _hostEnvironment.WebRootPath;
                    string fileName = Path.GetFileNameWithoutExtension(f.FileName);
                    string extension = Path.GetExtension(f.FileName);
                    fileName = fileName + DateTime.Now.ToString("yymmssfff") + extension;
                    destinationWedding.Destination_Img = fileName;
                    string path = Path.Combine(wwwRootPath + "/Images/DestinationWedding", fileName);
                    FileStream fileStream1 = new FileStream(path, FileMode.Create);
                    f.CopyTo(fileStream1);
                }

                _context.Add(destinationWedding);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(destinationWedding);
        }

        // GET: Admin/DestinationWeddings/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var destinationWedding = await _context.DestinationWedding.FindAsync(id);
            if (destinationWedding == null)
            {
                return NotFound();
            }
            return View(destinationWedding);
        }

        // POST: Admin/DestinationWeddings/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Destination_Img,Destination_Heading,IsNational,IsInterNational,IsActive")] DestinationWedding destinationWedding)
        {
            if (id != destinationWedding.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(destinationWedding);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DestinationWeddingExists(destinationWedding.ID))
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
            return View(destinationWedding);
        }

        // GET: Admin/DestinationWeddings/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var destinationWedding = await _context.DestinationWedding
                .FirstOrDefaultAsync(m => m.ID == id);
            if (destinationWedding == null)
            {
                return NotFound();
            }

            return View(destinationWedding);
        }

        // POST: Admin/DestinationWeddings/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var destinationWedding = await _context.DestinationWedding.FindAsync(id);
            _context.DestinationWedding.Remove(destinationWedding);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DestinationWeddingExists(int id)
        {
            return _context.DestinationWedding.Any(e => e.ID == id);
        }
    }
}
