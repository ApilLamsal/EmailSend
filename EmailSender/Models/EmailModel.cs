using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Net.Mail;

namespace EmailSender.Models
{
    public class EmailModel
    {
        
        [DisplayName("Email")]
        [Required]
        [EmailAddress]
        public string To { get; set; }

        [DisplayName("Subject")]
        public string Subject { get; set; }

        [DisplayName("Massage Text")]
        public string Text { get; set; }

        public void sendMail()
        {
            MailMessage mailMessage = new MailMessage("From", "To");
        }
    }
}
