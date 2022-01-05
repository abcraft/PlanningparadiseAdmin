using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PlanningParadiseAdmin.ViewModel
{
    public class TeamVM
    {
        public int ID { get; set; }
        public string Member_Name { get; set; }
        public string Designatin { get; set; }
        public string Member_Text { get; set; }
        public string Member_Img { get; set; }
        public string ExistingMember_Img { get; set; }
        public bool IsAcctive { get; set; }
    }
}
