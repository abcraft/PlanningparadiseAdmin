using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PlanningParadiseAdmin.ViewModel
{
    public class HomeVM
    {
        public int Id { get; set; }
        public string Welcome_Heading { get; set; }
        public string Welcome_Text { get; set; }
        public string WWA_Heading { get; set; }
        public string WWA_Text { get; set; }
        public string WWA_Img1 { get; set; }
        public string WWA_Img2 { get; set; }
        public bool IsActive { get; set; }
    }
}
