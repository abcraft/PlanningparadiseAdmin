using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PlanningParadiseAdmin.ViewModel
{
    public class GalleryVM
    {
        public int ID { get; set; }
        public string Gallery_Img { get; set; }
        public string Gallery_Video { get; set; }
        public bool IsActive { get; set; }
    }
}
