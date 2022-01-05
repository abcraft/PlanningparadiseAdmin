﻿using System;
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
    public class BlogsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IWebHostEnvironment _hostEnvironment;

        public BlogsController(ApplicationDbContext context, IWebHostEnvironment hostEnvironment)
        {
            _context = context;
            this._hostEnvironment = hostEnvironment;
        }

        // GET: Admin/Blogs
        public async Task<IActionResult> Index()
        {
            return View(await _context.Blogs.ToListAsync());
        }

        // GET: Admin/Blogs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var blog = await _context.Blogs
                .FirstOrDefaultAsync(m => m.ID == id);
            if (blog == null)
            {
                return NotFound();
            }

            return View(blog);
        }

        // GET: Admin/Blogs/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Admin/Blogs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Blog_Img,Blog_Heading,BlogShort_Detail,BlogLong_Detail,IsActive")] Blog blog)
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
                    blog.Blog_Img = fileName;
                    string path = Path.Combine(wwwRootPath + "/Images/blogs", fileName);
                    FileStream fileStream1 = new FileStream(path, FileMode.Create);
                    f.CopyTo(fileStream1);
                }

                _context.Add(blog);
                await _context.SaveChangesAsync();
                TempData["message"] = "Saved";
                return RedirectToAction(nameof(Index));
            }
            return View(blog);
        }

        // GET: Admin/Blogs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var blog = await _context.Blogs.FindAsync(id);
            BlogsVM bvm = new BlogsVM();
            bvm.ID = blog.ID;
            bvm.Blog_Heading = blog.Blog_Heading;
            bvm.Blog_Img = blog.Blog_Img;
            bvm.ExistingBlog_Img = blog.Blog_Img;
            bvm.BlogLong_Detail = blog.BlogLong_Detail;
            bvm.BlogShort_Detail = blog.BlogShort_Detail;
            bvm.IsActive = blog.IsActive;
            

            
            if (blog == null)
            {
                return NotFound();
            }
            return View(bvm);
        }

        // POST: Admin/Blogs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id,BlogsVM bvm)
        {
            if (id != bvm.ID)
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
                        string path = Path.Combine(wwwRootPath + "/Images/blogs", fileName);
                        FileStream fileStream1 = new FileStream(path, FileMode.Create);
                        f.CopyTo(fileStream1);

                    }
                    else
                    {
                        uniqueFileName = bvm.ExistingBlog_Img;
                    }
                    Blog blog = new Blog();
                    blog.ID = bvm.ID;
                    blog.Blog_Heading = bvm.Blog_Heading;
                    blog.Blog_Img = uniqueFileName;
                    blog.BlogLong_Detail = bvm.BlogLong_Detail;
                    blog.BlogShort_Detail = bvm.BlogShort_Detail;
                    blog.IsActive = bvm.IsActive;
                    _context.Update(blog);


                    await _context.SaveChangesAsync();
                    TempData["message"] = "Updated";
                    return RedirectToAction(nameof(Index));
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BlogExists(bvm.ID))
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
            return View(bvm);
        }

        // GET: Admin/Blogs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var blog = await _context.Blogs
                .FirstOrDefaultAsync(m => m.ID == id);
            if (blog == null)
            {
                return NotFound();
            }

            return View(blog);
        }

        // POST: Admin/Blogs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var blog = await _context.Blogs.FindAsync(id);
            _context.Blogs.Remove(blog);
            await _context.SaveChangesAsync();
            TempData["message"] = "Delete";
            return RedirectToAction(nameof(Index));
        }

        private bool BlogExists(int id)
        {
            return _context.Blogs.Any(e => e.ID == id);
        }
    }
}
