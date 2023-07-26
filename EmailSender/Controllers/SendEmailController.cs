using Microsoft.AspNetCore.Mvc;
using System.Net.Mail;
using System.Net;
using NuGet.Protocol.Plugins;

namespace EmailSender.Controllers
{
    public class SendEmailController : Controller
    {
        public IActionResult Send()
        {
            return View();
        }
       [HttpPost]
        public IActionResult Send(string To, string Subject, string Text)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var senderEmail = new MailAddress("Everestdogg@gmail.com");
                    var receiverEmail = new MailAddress(To, "To");
                    var password = "sqgyovpzzmhkjsrf";
                    var sub = Subject;
                    var body = Text;
                    var smtp = new SmtpClient
                    {
                        Host = "smtp.gmail.com",
                        Port = 587,
                        EnableSsl = true,
                        DeliveryMethod = SmtpDeliveryMethod.Network,
                        UseDefaultCredentials = false,
                        Credentials = new NetworkCredential(senderEmail.Address, password)
                    };
                    using (var mess = new MailMessage(senderEmail, receiverEmail)
                    {
                        Subject = Subject,
                        Body = Text
                    })
                    {
                        smtp.Send(mess);
                        ViewBag.success = "Successfully sent..";
                    }
                    ModelState.Clear();
                    return View();
                    
                }
            }
            catch (Exception)
            {
                ViewBag.Error = "Some Error";
            }
            return View();
        }
    }
}
