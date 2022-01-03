using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PlanningParadiseAdmin.ViewModel
{
    public class BlogsVM
    {
        public int ID { get; set; }
        public string Blog_Img { get; set; }
        public string Blog_Heading { get; set; }
        public string BlogShort_Detail { get; set; }
        public string BlogLong_Detail { get; set; }
        public bool IsActive { get; set; }
    }
}
