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

        public async Task<IActionResult> Banner()
        {
            var banner = await _context.Banner.FindAsync(1);
            if (banner == null)
            {
                return NotFound();
            }
            return View(banner);
        }
        [HttpPost]
        public async Task<IActionResult> Banner(Banner banner)
        {
            var b1 = await _context.Banner.FirstOrDefaultAsync(e => e.ID == 1);
            if (banner.AboutBanner_Img == null)
                banner.AboutBanner_Img = b1.AboutBanner_Img;
            if (banner.ServiceBanner_Img == null)
                banner.ServiceBanner_Img = b1.ServiceBanner_Img;
            if (banner.DestinationBanner_Img == null)
                banner.DestinationBanner_Img = b1.DestinationBanner_Img;
            if (banner.GalleryBanner_Img == null)
                banner.GalleryBanner_Img = b1.GalleryBanner_Img;
            if (banner.BlogBanner_Img == null)
                banner.BlogBanner_Img = b1.BlogBanner_Img;
            if (banner.FaqBanner_Img == null)
                banner.FaqBanner_Img = b1.FaqBanner_Img;
            if (banner.ContactBanner_Img == null)
                banner.ContactBanner_Img = b1.ContactBanner_Img;
           
            foreach (var item in HttpContext.Request.Form.Files)
            {
                if (item.Length > 0)
                {
                    var f = item;
                    string wwwRootPath = _hostEnvironment.WebRootPath;
                    string fileName = Path.GetFileNameWithoutExtension(f.FileName);
                    string extension = Path.GetExtension(f.FileName);
                    fileName = item.Name + DateTime.Now.ToString("yymmssfff") + extension;
                    string path = Path.Combine(wwwRootPath + "/Images/Banner", fileName);
                    if (item.Name == "AboutBanner_Img")
                    {
                        var path1 = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\Images\\Banner", b1.AboutBanner_Img);

                        if (System.IO.File.Exists(path1))
                        {
                            System.IO.File.Delete(path1);
                        }
                        banner.AboutBanner_Img = fileName;
                    }
                    if (item.Name == "ServiceBanner_Img")
                    {
                        var path1 = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\Images\\Banner", b1.ServiceBanner_Img);

                        if (System.IO.File.Exists(path1))
                        {
                            System.IO.File.Delete(path1);
                        }
                        banner.ServiceBanner_Img = fileName;
                    }
                    if (item.Name == "DestinationBanner_Img")
                    {
                        var path1 = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\Images\\Banner", b1.DestinationBanner_Img);

                        if (System.IO.File.Exists(path1))
                        {
                            System.IO.File.Delete(path1);
                        }
                        banner.DestinationBanner_Img = fileName;
                    }
                    if (item.Name == "GalleryBanner_Img")
                    {
                        var path1 = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\Images\\Banner", b1.GalleryBanner_Img);

                        if (System.IO.File.Exists(path1))
                        {
                            System.IO.File.Delete(path1);
                        }
                        banner.GalleryBanner_Img = fileName;
                    }
                    if (item.Name == "FaqBanner_Img")
                    {
                        var path1 = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\Images\\Banner", b1.FaqBanner_Img);

                        if (System.IO.File.Exists(path1))
                        {
                            System.IO.File.Delete(path1);
                        }
                        banner.FaqBanner_Img = fileName;
                    }
                    if (item.Name == "BlogBanner_Img")
                    {
                        var path1 = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\Images\\Banner", b1.BlogBanner_Img);
                        if (System.IO.File.Exists(path1))
                        {
                            System.IO.File.Delete(path1);
                        }
                        banner.BlogBanner_Img = fileName;
                    }
                    if (item.Name == "ContactBanner_Img")
                    {
                        var path1 = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\Images\\Banner", b1.ContactBanner_Img);
                        if (System.IO.File.Exists(path1))
                        {
                            System.IO.File.Delete(path1);
                        }
                        banner.ContactBanner_Img = fileName;
                    }
                  
                    FileStream fileStream1 = new FileStream(path, FileMode.Create);
                    f.CopyTo(fileStream1);

                }

            }
            b1.AboutBanner_Heading = banner.AboutBanner_Heading;
            b1.AboutBanner_Img = banner.AboutBanner_Img;
            b1.ServiceBanner_Heading = banner.ServiceBanner_Heading;
            b1.ServiceBanner_Img = banner.ServiceBanner_Img;
            b1.DestinationBanner_Heading = banner.DestinationBanner_Heading;
            b1.DestinationBanner_Img = banner.DestinationBanner_Img;
            b1.GalleryBanner_Heading = banner.GalleryBanner_Heading;
            b1.GalleryBanner_Img = banner.GalleryBanner_Img;
            b1.BlogBanner_Heading = banner.BlogBanner_Heading;
            b1.BlogBanner_Img = banner.BlogBanner_Img;
            b1.FaqBanner_Heading = banner.FaqBanner_Heading;
            b1.FaqBanner_Img = banner.FaqBanner_Img;
            b1.ContactBanner_Heading = banner.ContactBanner_Heading;
            b1.ContactBanner_Img = banner.ContactBanner_Img;


            _context.Entry(b1).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return View(banner);
        }


        private bool HomeExists(int id)
        {
            return _context.Home.Any(e => e.Id == id);
        }
    }
}
