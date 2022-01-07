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
            List<TestimonialVM> testimonialVMlist = new List<TestimonialVM>();
            var testimonials = (from c in _context.Testimonials select c).ToList();
            foreach (var item in testimonials)
            {
                TestimonialVM testimonialVM = new TestimonialVM();
                testimonialVM.ID = item.ID;
                testimonialVM.Testimonial_Img = item.Testimonial_Img;
                testimonialVM.Testimonial_Name = item.Testimonial_Name;
                testimonialVM.Testimonial_Order = item.Testimonial_Order;
                testimonialVM.Testimonial_Text = item.Testimonial_Text;
                testimonialVM.IsAvtive = item.IsAvtive;
               

                testimonialVMlist.Add(testimonialVM);
            }

            SessionHelper.SetObjectAsJson(HttpContext.Session, "Sliders", SliderVMlist);
            SessionHelper.SetObjectAsJson(HttpContext.Session, "WWAImages", wWAImagesVMlist);
            SessionHelper.SetObjectAsJson(HttpContext.Session, "Testimonials", testimonialVMlist);
            var home =  _context.Home
                .FirstOrDefault(m => m.Id == 1);
            return View(home);
        }
        public IActionResult AboutUs()
        {
            var AboutContent = _context.AboutUs
                .FirstOrDefault(m => m.ID == 1);
            var whychooseus = (from c in _context.WhyChoosUs select c).ToList();
            var WhyChoosePointslist = (from c in _context.WhyChoosePoints select c).ToList();
            var Teams = (from c in _context.Team select c).ToList();
            SessionHelper.SetObjectAsJson(HttpContext.Session, "Teams", Teams);
            SessionHelper.SetObjectAsJson(HttpContext.Session, "WhyChooseUsPoints", WhyChoosePointslist);
            SessionHelper.SetObjectAsJson(HttpContext.Session, "WhyChooseUs", whychooseus);

            return View(AboutContent);
        }
        public IActionResult Services()
        {
            var services = _context.Services.ToList();
            return View(services);
        }
        public IActionResult DestinationWedding()
        {
            var Nationalweedings = _context.DestinationWedding
                .Where(m => m.IsNational == true).ToList();
            var InterNationalweedings = _context.DestinationWedding
                .Where(m => m.IsInterNational == true).ToList();
            SessionHelper.SetObjectAsJson(HttpContext.Session, "Nationalweedings", Nationalweedings);
            SessionHelper.SetObjectAsJson(HttpContext.Session, "InterNationalweedings", InterNationalweedings);
            return View();
        }
        public IActionResult Gallery()
        {
            var galleries = _context.Gallery.ToList();
            return View(galleries);
        }
        public IActionResult Blogs()
        {
            var blogs = _context.Blogs.ToList();
            return View(blogs);
        }
        public IActionResult FAQs()
        {
            var faqs = _context.FAQ.ToList();
            return View(faqs);
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
