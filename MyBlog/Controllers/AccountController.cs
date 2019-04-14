using System.Linq;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using MyBlog.Models.DataBase;
using MyBlog.Models.View;
using static MyBlog.Models.DataBase.BlogEntities;

namespace MyBlog.Controllers
{
    public class AccountController : Controller
    {

        BlogContext _db;
        UserModel _model;
        
        public AccountController(BlogContext db, UserModel model)
        {
            _db = db;
            _model = model;
            
        }
        public IActionResult Login()
        {
            return View(_model);
        }
        [HttpPost]
        public IActionResult Login(UserModel um)
        {
            
            var user = _db.Set<User>().FirstOrDefault(x => x.Email == um.User.Email && x.Password == um.User.Password);
            if (user != null)
            {
                HttpContext.Session.SetString("User", um.User.Email.ToString());
                return RedirectToAction("Index", "Home");
            }
            else
            {
                //ViewData["Message"] = "Hatalı Giriş";
                return RedirectToAction("Login", "Account");
            }
        }
        public IActionResult AdminPage()
        {

            
            ViewBag.session = HttpContext.Session.GetString("User");
            
            return View(_model);
        }
        
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Login", "Account");
        }

    }
}