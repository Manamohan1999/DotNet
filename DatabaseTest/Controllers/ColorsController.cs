using DatabaseTest.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DatabaseTest.Controllers
{
    public class ColorsController : Controller
    {
        private readonly AppDbContext context;

        public ColorsController(AppDbContext context)
        {
            this.context = context;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(string color)
        {
            Color cl = new Color();
            cl.ColorHex = color;
            context.Add(cl);
            context.SaveChanges();
            return View();
        }
    }
}
