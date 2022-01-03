using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PlanningParadiseAdmin.ViewModel
{
    public class ServicesVM
    {
        public int ID { get; set; }
        public string Service_Img { get; set; }
        public string Service_Heading { get; set; }
        public string Servie_Text { get; set; }
        public bool IsActive { get; set; }
    }
}
