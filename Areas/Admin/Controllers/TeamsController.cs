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
    public class TeamsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IWebHostEnvironment _hostEnvironment;

        public TeamsController(ApplicationDbContext context, IWebHostEnvironment hostEnvironment)
        {
            _context = context;
            this._hostEnvironment = hostEnvironment;
        }

        // GET: Admin/Teams
        public async Task<IActionResult> Index()
        {
            return View(await _context.Team.ToListAsync());
        }

        // GET: Admin/Teams/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var team = await _context.Team
                .FirstOrDefaultAsync(m => m.ID == id);
            if (team == null)
            {
                return NotFound();
            }

            return View(team);
        }

        // GET: Admin/Teams/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Admin/Teams/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Member_Name,Designatin,Member_Text,Member_Img,IsAcctive")] Team team)
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
                    team.Member_Img = fileName;
                    string path = Path.Combine(wwwRootPath + "/Images/team", fileName);
                    FileStream fileStream1 = new FileStream(path, FileMode.Create);
                    f.CopyTo(fileStream1);
                }
                _context.Add(team);
                await _context.SaveChangesAsync();
                TempData["message"] = "Saved";
                return RedirectToAction(nameof(Index));
            }
            return View(team);
        }

        // GET: Admin/Teams/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var team = await _context.Team.FindAsync(id);
            TeamVM tvm = new TeamVM();
            tvm.ID = team.ID;
            tvm.Member_Name = team.Member_Name;
            tvm.Member_Img = team.Member_Img;
            tvm.ExistingMember_Img = team.Member_Img;
            tvm.Designatin = team.Designatin;
            tvm.Member_Text = team.Member_Text;
            tvm.IsAcctive = team.IsAcctive;

            if (team == null)
            {
                return NotFound();
            }
            return View(tvm);
        }

        // POST: Admin/Teams/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id,TeamVM tvm)
        {
            if (id != tvm.ID)
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
                        string path = Path.Combine(wwwRootPath + "/Images/team", fileName);
                        FileStream fileStream1 = new FileStream(path, FileMode.Create);
                        f.CopyTo(fileStream1);

                    }
                    else
                    {
                        uniqueFileName = tvm.ExistingMember_Img;
                    }
                    Team team = new Team();
                    team.ID = tvm.ID;
                    team.Member_Name = tvm.Member_Name;
                    team.Member_Img = uniqueFileName;
                    team.Member_Text = tvm.Member_Text;
                    team.Designatin = tvm.Designatin;
                    team.IsAcctive = tvm.IsAcctive;
                    _context.Update(team);


                    await _context.SaveChangesAsync();
                    TempData["message"] = "Updated";
                    return RedirectToAction(nameof(Index));
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TeamExists(tvm.ID))
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
            return View(tvm);
        }

        // GET: Admin/Teams/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var team = await _context.Team
                .FirstOrDefaultAsync(m => m.ID == id);
            if (team == null)
            {
                return NotFound();
            }

            return View(team);
        }

        // POST: Admin/Teams/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var team = await _context.Team.FindAsync(id);
            _context.Team.Remove(team);
            await _context.SaveChangesAsync();
            TempData["message"] = "Delete";
            return RedirectToAction(nameof(Index));
        }

        private bool TeamExists(int id)
        {
            return _context.Team.Any(e => e.ID == id);
        }
    }
}
