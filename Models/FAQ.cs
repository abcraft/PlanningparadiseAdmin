using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PlanningParadiseAdmin.Models
{
    public class FAQ
    {
        public int ID { get; set; }
        public string Faq_Heading { get; set; }
        public string Faq_Text { get; set; }
        public bool IsActive { get; set; }
    }
}
