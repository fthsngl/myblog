
using System.Net;
using System.Net.Mail;

using Microsoft.AspNetCore.Mvc;
using MyBlog.Models.DataBase;
using MyBlog.Models.View;


namespace MyBlog.Controllers
{
    public class ContactController : Controller
    {
        BlogContext _db;
        MessageModel _model;
         
        public ContactController(BlogContext db, MessageModel model)
        {
            _db = db;
            _model = model;

        }
        public IActionResult Contact()
        {
            return View(_model);
        }
        [HttpPost]
        public IActionResult Contact(string mailbody, MessageModel mesmo)
        {
            _db.Entry(mesmo.Message).State = Microsoft.EntityFrameworkCore.EntityState.Added;
            _db.SaveChanges();
            using (var message = new MailMessage(mesmo.Message.Email, "granobrablog.@gmail.com"))
            {
                message.To.Add(new MailAddress("granobrablog.@gmail.com"));
                message.From = new MailAddress(mesmo.Message.Email);
                message.Subject = "Test";
                message.Body = mailbody;

                using (var smtpClient = new SmtpClient("smtp.gmail.com", 587))
                {
                    smtpClient.Credentials = new NetworkCredential("granobrablog.@gmail.com", "kolaybiseyolsun.,q");
                    smtpClient.EnableSsl = true;
                    smtpClient.Send(message);
                };
                
            }
            
            return RedirectToAction("Contact", "Contact");

        }

    }
}