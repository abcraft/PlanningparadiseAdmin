using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PlanningParadiseAdmin.Models
{
    public class DestinationWedding
    {
        public int ID { get; set; }
        public string Destination_Img { get; set; }
        public string Destination_Heading { get; set; }
        public bool IsNational { get; set; }
        public bool IsInterNational { get; set; }
        public bool IsActive { get; set; }
    }
}
