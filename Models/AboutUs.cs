using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PlanningParadiseAdmin.Models
{
    public class AboutUs
    {
        public int ID { get; set; }
        public string About_Heading { get; set; }
        public string About_Para1 { get; set; }
        public string About_Para2 { get; set; }
        public string About_Para3 { get; set; }
        public string About_Qoute { get; set; }
        public bool IsActive { get; set; }
    }
}
