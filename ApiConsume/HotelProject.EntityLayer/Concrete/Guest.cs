using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelProject.EntityLayer.Concrete
{
    public class Guest
    {
        public int GuestID { get; set; }
        public int GuestTcNumber { get; set; }
        public string GuestName { get; set; }
        public string GuestSurName { get; set; }
        public string GuestGender { get; set; }
        public string GuestCity { get; set; }
        public string GuestPhone { get; set; }
        
    }
}
