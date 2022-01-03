using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PlanningParadiseAdmin.Models
{
    public class Home
    {
        public int Id { get; set; }
        public string Welcome_Heading { get; set; }
        public string Welcome_Text { get; set; }
        public string WWA_Heading { get; set; }
        public string WWA_Text { get; set; }
        public bool IsActive { get; set; }

    }
}
