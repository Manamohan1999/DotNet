using BookTurf.Services.Interfaces;
using BookTurf.Web.Models;
using BookTurf.Web.Models.ViewModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookTurf.Web.Controllers
{

    //[Route("/[controller]/[action]")]
    public class LoginController : Controller
    {
        private readonly ILoginService loginService;
        private int? loginId;
        private string userName;

        public LoginController(ILoginService loginService)
        {
            this.loginService = loginService;
        }

        public IActionResult Index()
        {
            userName = HttpContext.Session.GetString("UserName");
            loginId = (int?)HttpContext.Session.GetInt32("LoginId");

            if(userName != null && loginId != 0)
            {
                return RedirectToAction("Dashboard", "Admin");
            }

            if(HttpContext.Request.Cookies["UserName"] != null && HttpContext.Request.Cookies["Password"] != null)
            {
                return View(new Login()
                {
                    UserId = HttpContext.Request.Cookies["UserName"],
                    Password = HttpContext.Request.Cookies["Password"],
                    RememberMe = true
                });
            }


            return View();
        }

        [HttpPost]
        public IActionResult Index(Login model)
        {

            var user = loginService.GetById(model.UserId, model.Password);
            if(user != null)
            {
                loginId = user.LoginId;
                userName = user.UserName;

                HttpContext.Session.SetString("UserName", userName);
                HttpContext.Session.SetInt32("LoginId", loginId.GetValueOrDefault());

                if (model.RememberMe)
                {
                    HttpContext.Response.Cookies.Append("UserName", userName);
                    HttpContext.Response.Cookies.Append("Password", model.Password);
                }

                return RedirectToAction("Dashboard", "Admin");
            }
            else
            {
                var errorMessage = "";
                if(loginService.GetUsername(model.UserId) == "success")
                {
                    errorMessage = "Invalid Password";
                }
                else
                {
                    if(loginService.GetPassword(model.Password) == "success")
                    {
                        errorMessage = "Invalid UserId";
                    }
                    errorMessage = "Invalid Login Credentials";
                }
                TempData["ErrorMessage"] = errorMessage;
                return View();
            }
        }

        public IActionResult ForgotPassword()
        {
            return View();
        }

        [HttpPost]
        public IActionResult ForgotPassword(ForgotPasswordViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = loginService.GetUsername(model.Email);
                if(user != null)
                {
                    //generate random token
                    var token = RandomString(5);
                    var result = loginService.UpdateForgotPasswordToken(model.Email, token);
                    if (result)
                    {
                        var passwordResetLink = Url.Action("ResetPassword", "Login", new { token = token }, Request.Scheme);
                        return Redirect(passwordResetLink);
                    }
                }
                else
                {
                    TempData["ErrorMessage"] = "Invalid Email-Id";
                }
            }
            return View(model);
        }

        public IActionResult ResetPassword()
        {
            return View();
        }

        [HttpPost]
        public IActionResult ResetPassword(ResetPasswordViewModel model, string token)
        {
            if (ModelState.IsValid)
            {
                var user = loginService.GetByToken(token);
                if (user != null)
                {
                    var result = loginService.UpdatePassword(user.UserName, model.Password);
                    if (result)
                    {
                        loginService.UpdateForgotPasswordToken(user.UserName, null);
                        return RedirectToAction("Index", "Login");
                    }
                }
            }
            
            return View(model);
        }

        //generate random string of specified size
        public string RandomString(int size)
        {
            StringBuilder builder = new StringBuilder();
            Random random = new Random();
            char ch;
            for (int i = 0; i < size; i++)
            {
                ch = Convert.ToChar(Convert.ToInt32(Math.Floor(26 * random.NextDouble() + 65)));
                builder.Append(ch);
            }
            return builder.ToString();
        }
    }
}
