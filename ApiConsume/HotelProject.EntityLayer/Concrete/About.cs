using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelProject.EntityLayer.Concrete
{
    public class About
    {
        public int AboutID { get; set; }
        public string AboutTitle1 { get; set; }
        public string AboutTitle2 { get; set; }
        public string AboutContent { get; set; }
        public int AboutRoomCount { get; set; }
        public int AboutStaffCount { get; set; }
        public int AboutCustomerCount { get; set; }
    }
}
