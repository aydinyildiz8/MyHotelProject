using HotelProject.DataAccessLayer.Concrete;
using HotelProject.EntityLayer.Concrete;
using HotelProject.WebUI.Dtos.ContactDto;
using HotelProject.WebUI.Models.Mail;
using MailKit.Net.Smtp;
using Microsoft.AspNetCore.Mvc;
using MimeKit;
using System;

namespace HotelProject.WebUI.Controllers
{
    public class MailAdminController : Controller
    {

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(AdminMailViewModel adminMailViewModel)
        {
            MimeMessage mimeMessage = new MimeMessage();

            MailboxAddress mailboxAddressFrom = new MailboxAddress("Admin", "aydnyldz8@gmail.com");
            mimeMessage.From.Add(mailboxAddressFrom);

            MailboxAddress mailboxAddressTo = new MailboxAddress(adminMailViewModel.ReceiverMail, adminMailViewModel.ReceiverMail);
            mimeMessage.To.Add(mailboxAddressTo);

            var bodyBuilder = new BodyBuilder();
            bodyBuilder.TextBody = adminMailViewModel.Body;
            mimeMessage.Body = bodyBuilder.ToMessageBody();

            mimeMessage.Subject = adminMailViewModel.Subject;

            SmtpClient client = new SmtpClient();
            client.Connect("smtp.gmail.com", 587, false);
            client.Authenticate("aydnyldz8@gmail.com", "ucokkiecybxludmr");
            client.Send(mimeMessage);
            client.Disconnect(true);

            using (var context = new Context())
            {
                var adminMail = new SendMessage()
                {

                    SenderMail = "aydnyldz8@gmail.com",
                    SendMessageDate = DateTime.Now,
                    ReceiverName = "User",
                    SenderName = "Admin",
                    ReveiverMail = adminMailViewModel.ReceiverMail,
                    SendMessageContent = adminMailViewModel.Subject,
                    SendMessageMessage = adminMailViewModel.Body,

                };

                context.sendMessages.Add(adminMail);
                context.SaveChanges();
            }

            return RedirectToAction("Sendbox", "ContactAdmin");
        }
    }
}
