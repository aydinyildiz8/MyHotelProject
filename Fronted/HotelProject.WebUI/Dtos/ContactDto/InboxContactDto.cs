using System;

namespace HotelProject.WebUI.Dtos.ContactDto
{
    public class InboxContactDto
    {
        public int ContactID { get; set; }
        public string ContactName { get; set; }
        public string ContactMail { get; set; }
        public string ContactSubject { get; set; }
        public string ContactMessage { get; set; }
        public DateTime ContactDate { get; set; }
    }
}
