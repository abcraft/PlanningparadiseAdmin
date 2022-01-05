using System;
using System.Collections.Generic;
using System.IO;
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
    public class GalleriesController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IWebHostEnvironment _hostEnvironment;

        public GalleriesController(ApplicationDbContext context, IWebHostEnvironment hostEnvironment)
        {
            _context = context;
            this._hostEnvironment = hostEnvironment;
        }

        // GET: Admin/Galleries
        public async Task<IActionResult> Index()
        {
            return View(await _context.Gallery.ToListAsync());
        }

        // GET: Admin/Galleries/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var gallery = await _context.Gallery
                .FirstOrDefaultAsync(m => m.ID == id);
            if (gallery == null)
            {
                return NotFound();
            }

            return View(gallery);
        }

        // GET: Admin/Galleries/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Admin/Galleries/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Gallery_Img,Gallery_Video,IsActive")] Gallery gallery)
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
                    gallery.Gallery_Img = fileName;
                    string path = Path.Combine(wwwRootPath + "/Images/gallery", fileName);
                    FileStream fileStream1 = new FileStream(path, FileMode.Create);
                    f.CopyTo(fileStream1);

                }

                _context.Add(gallery);
                await _context.SaveChangesAsync();
                TempData["message"] = "Saved";
                return RedirectToAction(nameof(Index));
            }
            return View(gallery);
        }

        // GET: Admin/Galleries/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var gallery = await _context.Gallery.FindAsync(id);
            GalleryVM gvm = new GalleryVM();
            gvm.ID = gallery.ID;
            gvm.Gallery_Img = gallery.Gallery_Img;
            gvm.ExistingGallery_Img = gallery.Gallery_Img;

            if (gallery == null)
            {
                return NotFound();
            }
            return View(gvm);
        }

        // POST: Admin/Galleries/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, GalleryVM gvm)
        {
            if (id != gvm.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    string uniqueFileName = "";
                    if (HttpContext.Request.Form.Files.Count() > 0)
                    {
                        var f = HttpContext.Request.Form.Files[0];
                        string wwwRootPath = _hostEnvironment.WebRootPath;
                        string fileName = Path.GetFileNameWithoutExtension(f.FileName);
                        string extension = Path.GetExtension(f.FileName);
                        fileName = fileName + DateTime.Now.ToString("yymmssfff") + extension;
                        uniqueFileName = fileName;
                        string path = Path.Combine(wwwRootPath + "/Images/gallery", fileName);
                        FileStream fileStream1 = new FileStream(path, FileMode.Create);
                        f.CopyTo(fileStream1);

                    }
                    else
                    {
                        uniqueFileName = gvm.ExistingGallery_Img;
                    }
                    Gallery gallery = new Gallery();
                    gallery.ID = gvm.ID;
                    gallery.Gallery_Img = uniqueFileName;
                    gallery.IsActive = gvm.IsActive;
                    _context.Update(gallery);

                    await _context.SaveChangesAsync();
                    TempData["message"] = "Updated";
                    return RedirectToAction(nameof(Index));
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!GalleryExists(gvm.ID))
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
            return View(gvm);
        }

        // GET: Admin/Galleries/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var gallery = await _context.Gallery
                .FirstOrDefaultAsync(m => m.ID == id);
            if (gallery == null)
            {
                return NotFound();
            }

            return View(gallery);
        }

        // POST: Admin/Galleries/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var gallery = await _context.Gallery.FindAsync(id);
            _context.Gallery.Remove(gallery);
            await _context.SaveChangesAsync();
            TempData["message"] = "Delete";
            return RedirectToAction(nameof(Index));
        }

        private bool GalleryExists(int id)
        {
            return _context.Gallery.Any(e => e.ID == id);
        }
    }
}
