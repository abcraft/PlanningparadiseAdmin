using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PlanningParadiseAdmin.Models
{
    public class Testimonial
    {
        public int ID { get; set; }
        public string Testimonial_Img { get; set; }
        public string Testimonial_Name { get; set; }
        public string Testimonial_Text { get; set; }
        public int Testimonial_Order { get; set; }
        public bool IsAvtive { get; set; }
    }
}
