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
    public class ServicesController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IWebHostEnvironment _hostEnvironment;



        public ServicesController(ApplicationDbContext context, IWebHostEnvironment hostEnvironment)
        {
            _context = context;
            this._hostEnvironment = hostEnvironment;
        }

        // GET: Admin/Services
        public async Task<IActionResult> Index()
        {
            return View(await _context.Services.ToListAsync());
        }

        // GET: Admin/Services/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var services = await _context.Services
                .FirstOrDefaultAsync(m => m.ID == id);
            if (services == null)
            {
                return NotFound();
            }

            return View(services);
        }

        // GET: Admin/Services/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Admin/Services/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Service_Img,Service_Heading,Servie_Text,IsActive")] Services services)
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
                    services.Service_Img = fileName;
                    string path = Path.Combine(wwwRootPath + "/Images/services", fileName);
                    FileStream fileStream1 = new FileStream(path, FileMode.Create);
                    f.CopyTo(fileStream1);
                }
                _context.Add(services);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(services);
        }

        // GET: Admin/Services/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var services = await _context.Services.FindAsync(id);
            if (services == null)
            {
                return NotFound();
            }
            return View(services);
        }

        // POST: Admin/Services/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Service_Img,Service_Heading,Servie_Text,IsActive")] Services services)
        {
            if (id != services.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(services);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ServicesExists(services.ID))
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
            return View(services);
        }

        // GET: Admin/Services/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var services = await _context.Services
                .FirstOrDefaultAsync(m => m.ID == id);
            if (services == null)
            {
                return NotFound();
            }

            return View(services);
        }

        // POST: Admin/Services/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var services = await _context.Services.FindAsync(id);
            _context.Services.Remove(services);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ServicesExists(int id)
        {
            return _context.Services.Any(e => e.ID == id);
        }
    }
}
