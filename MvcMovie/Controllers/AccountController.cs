using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MvcMovie.Data;
using MvcMovie.Models;
using MvcMovie.Models.ViewModel;
using System;
using System.Linq;

namespace MvcMovie.Controllers
{
    public class AccountController : Controller
    {
        private readonly MovieContext context;
        private string uname;
        private string pass;

        public AccountController(MovieContext context)
        {
            this.context = context;
        }
        public IActionResult Index()
        {
            uname = HttpContext.Session.GetString("uname");
            if(uname != null)
            {
                return View("Login");
            }
            uname = HttpContext.Request.Cookies["uname"];
            pass = HttpContext.Request.Cookies["pass"];
            if(uname != null && pass != null)
            {
                Account account = new Account() {Username = uname, Password = pass };
                return View(account);
            }
            return View();
        }

        [HttpPost]
        public IActionResult Login(Account model)
        {
            uname = model.Username;
            pass = model.Password;
            var isChecked = model.Remember;

            var users = from m in context.Accounts
                       where m.Username == uname && m.Password == pass
                       select m;
            var user = users.ToList().FirstOrDefault();
            if(user != null)
            {
                HttpContext.Session.SetString("uname", uname);

                if (isChecked)
                {
                    HttpContext.Response.Cookies.Append("uname", uname);
                    HttpContext.Response.Cookies.Append("pass", pass);
                }

            }
            ViewData["uname"] = uname;
            return View();
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Remove("uname");
            HttpContext.Session.Remove("pass");
            return View("Index",new Account() { Username = HttpContext.Request.Cookies["uname"], Password = HttpContext.Request.Cookies["pass"]});
        }
    }
}
