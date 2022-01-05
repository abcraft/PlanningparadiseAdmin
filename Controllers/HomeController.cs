using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PlanningParadiseAdmin.Data;
using PlanningParadiseAdmin.Models;
using PlanningParadiseAdmin.ViewModel;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace PlanningParadiseAdmin.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext _context;

        public HomeController(ILogger<HomeController> logger,
            ApplicationDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            List<SliderVM> SliderVMlist = new List<SliderVM>();
            var sliders = (from c in _context.Sliders select c).ToList();
            foreach (var item in sliders)
            {
                SliderVM svm = new SliderVM();
                svm.ID = item.ID;
                svm.Slider_Heading = item.Slider_Heading;
                svm.Slider_SubHead = item.Slider_SubHead;
                svm.Slider_Img = item.Slider_Img;
                svm.Slider_Order = item.Slider_Order;
                svm.IsActive = item.IsActive;
                SliderVMlist.Add(svm);
            }
            List<WWAImagesVM> wWAImagesVMlist = new List<WWAImagesVM>();
            var wwAimages = (from c in _context.WWAImages select c).ToList();
            foreach (var item in wwAimages)
            {
                WWAImagesVM wwImgvm = new WWAImagesVM();
                wwImgvm.Id = item.Id;
                wwImgvm.WWA_Img1 = item.WWA_Img1;
                wwImgvm.WWA_Img2 = item.WWA_Img2;
                wwImgvm.WWA_Img3 = item.WWA_Img3;
                wwImgvm.WWA_Img4 = item.WWA_Img4;
                wwImgvm.WWA_Img5 = item.WWA_Img5;
                wwImgvm.WWA_Img6 = item.WWA_Img6;
                wwImgvm.WWA_Img7 = item.WWA_Img7;
                wwImgvm.WWA_Img8 = item.WWA_Img8;
                wwImgvm.WWA_Img9 = item.WWA_Img9;

                wWAImagesVMlist.Add(wwImgvm);
            }

            SessionHelper.SetObjectAsJson(HttpContext.Session, "Sliders", SliderVMlist);
            SessionHelper.SetObjectAsJson(HttpContext.Session, "WWAImages", wWAImagesVMlist);

            return View(_context.Home.ToList());
        }
        public IActionResult AboutUs()
        {
            return View();
        }
        public IActionResult Services()
        {
            return View();
        }
        public IActionResult DestinationWedding()
        {
            return View();
        }
        public IActionResult Gallery()
        {
            return View();
        }
        public IActionResult Blogs()
        {
            return View();
        }
        public IActionResult FAQs()
        {
            return View();
        }
        public IActionResult Contact()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
