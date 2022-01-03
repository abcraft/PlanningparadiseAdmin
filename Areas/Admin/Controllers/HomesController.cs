using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PlanningParadiseAdmin.Data;
using PlanningParadiseAdmin.Models;

namespace PlanningParadiseAdmin.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class HomesController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IWebHostEnvironment _hostEnvironment;

        public HomesController(ApplicationDbContext context, IWebHostEnvironment hostEnvironment)
        {
            _context = context;
            this._hostEnvironment = hostEnvironment;
        }

        // GET: Admin/Homes
        public async Task<IActionResult> Index()
        {
            return View(await _context.Home.ToListAsync());
        }

        // GET: Admin/Homes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var home = await _context.Home
                .FirstOrDefaultAsync(m => m.Id == id);
            if (home == null)
            {
                return NotFound();
            }

            return View(home);
        }

        // GET: Admin/Homes/Create
        public IActionResult Create()
        {
            return View();
        }
        public async Task<IActionResult> WWAImages()
        {
            var wWA = await _context.WWAImages.FirstOrDefaultAsync(e => e.Id == 1);
            return View(wWA);
        }

        // POST: Admin/Homes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> SaveText([Bind("Id,Welcome_Heading,Welcome_Text,WWA_Heading,WWA_Text")] Home home)
        {
            if (ModelState.IsValid)
            {
                home.IsActive = true;
                _context.Add(home);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(home);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> SaveImages()
        {
            //WWAImages wWA = new WWAImages();
            var wWA = await _context.WWAImages.FirstOrDefaultAsync(e => e.Id == 1 );

            foreach (var item in HttpContext.Request.Form.Files)
            {
                if (item.Length > 0)
                {
                    var f = item;
                    string wwwRootPath = _hostEnvironment.WebRootPath;
                    string fileName = Path.GetFileNameWithoutExtension(f.FileName);
                    string extension = Path.GetExtension(f.FileName);
                    fileName = item.Name + DateTime.Now.ToString("yymmssfff") + extension;
                    string path = Path.Combine(wwwRootPath + "/Images/wwaImages", fileName);
                    if (item.Name == "WWA_Img1")
                    {
                        var path1 = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\Images\\wwaImages", wWA.WWA_Img1);

                        if (System.IO.File.Exists(path1))
                        {
                            System.IO.File.Delete(path1);
                        }
                        wWA.WWA_Img1 = fileName;
                    }
                    if (item.Name == "WWA_Img2")
                    {
                        var path1 = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\Images\\wwaImages", wWA.WWA_Img2);

                        if (System.IO.File.Exists(path1))
                        {
                            System.IO.File.Delete(path1);
                        }
                        wWA.WWA_Img2 = fileName;
                    }
                    if (item.Name == "WWA_Img3")
                    {
                        var path1 = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\Images\\wwaImages", wWA.WWA_Img3);

                        if (System.IO.File.Exists(path1))
                        {
                            System.IO.File.Delete(path1);
                        }
                        wWA.WWA_Img3 = fileName;
                    }
                    if (item.Name == "WWA_Img4")
                    {
                        var path1 = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\Images\\wwaImages", wWA.WWA_Img4);

                        if (System.IO.File.Exists(path1))
                        {
                            System.IO.File.Delete(path1);
                        }
                        wWA.WWA_Img4 = fileName;
                    }
                    if (item.Name == "WWA_Img5")
                    {
                        var path1 = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\Images\\wwaImages", wWA.WWA_Img5);

                        if (System.IO.File.Exists(path1))
                        {
                            System.IO.File.Delete(path1);
                        }
                        wWA.WWA_Img5 = fileName;
                    }
                    if (item.Name == "WWA_Img6")
                    {
                        var path1 = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\Images\\wwaImages", wWA.WWA_Img6);
                        if (System.IO.File.Exists(path1))
                        {
                            System.IO.File.Delete(path1);
                        }
                        wWA.WWA_Img6 = fileName;
                    }
                    if (item.Name == "WWA_Img7")
                    {
                        var path1 = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\Images\\wwaImages", wWA.WWA_Img7);
                        if (System.IO.File.Exists(path1))
                        {
                            System.IO.File.Delete(path1);
                        }
                        wWA.WWA_Img7 = fileName;
                    }
                    if (item.Name == "WWA_Img8")
                    {
                        var path1 = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\Images\\wwaImages", wWA.WWA_Img8);
                        if (System.IO.File.Exists(path1))
                        {
                            System.IO.File.Delete(path1);
                        }
                        wWA.WWA_Img8 = fileName;
                    }
                    if (item.Name == "WWA_Img9")
                    {
                        var path1 = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\Images\\wwaImages", wWA.WWA_Img9);
                        if (System.IO.File.Exists(path1))
                        {
                            System.IO.File.Delete(path1);
                        }
                        wWA.WWA_Img9 = fileName;
                    }
                    
                    FileStream fileStream1 = new FileStream(path, FileMode.Create);
                    f.CopyTo(fileStream1);

                }
               
            }


            //home.IsActive = true;
            _context.Entry(wWA).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(WWAImages));
        }

        // GET: Admin/Homes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var home = await _context.Home.FindAsync(id);
            if (home == null)
            {
                return NotFound();
            }
            return View(home);
        }

        // POST: Admin/Homes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Welcome_Heading,Welcome_Text,WWA_Heading,WWA_Text,WWA_Img1,WWA_Img2,IsActive")] Home home)
        {
            if (id != home.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(home);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!HomeExists(home.Id))
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
            return View(home);
        }

        // GET: Admin/Homes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var home = await _context.Home
                .FirstOrDefaultAsync(m => m.Id == id);
            if (home == null)
            {
                return NotFound();
            }

            return View(home);
        }

        // POST: Admin/Homes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var home = await _context.Home.FindAsync(id);
            _context.Home.Remove(home);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool HomeExists(int id)
        {
            return _context.Home.Any(e => e.Id == id);
        }
    }
}
