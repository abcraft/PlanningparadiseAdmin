using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PlanningParadiseAdmin.ViewModel
{
    public class TestimonialVM
    {
        public int ID { get; set; }
        public string Testimonial_Img { get; set; }
        public string Testimonial_Name { get; set; }
        public string Testimonial_Text { get; set; }
        public int Testimonial_Order { get; set; }
        public bool IsAvtive { get; set; }
    }
}
