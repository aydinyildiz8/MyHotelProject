using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelProject.EntityLayer.Concrete
{
    public class SendMessage
    {
        public int SendMessageID { get; set; }
        public string SenderName { get; set; }
        public string SenderMail { get; set; }
        public string ReceiverName { get; set; }
        public string ReveiverMail { get; set; }
        public string SendMessageContent { get; set; }
        public string SendMessageMessage { get; set; }
        public DateTime SendMessageDate { get; set; }
    }
}
