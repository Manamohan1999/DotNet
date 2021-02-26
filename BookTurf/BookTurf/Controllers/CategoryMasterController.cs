using BookTurf.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookTurf.Web.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]/[action]")]
    public class CategoryMasterController : Controller
    {
      
        private readonly ICategoryMasterService _categoryMasterService;

        public CategoryMasterController(ICategoryMasterService categoryMasterService)
        {
            _categoryMasterService = categoryMasterService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult GetAllTrue()
        {
            var result = _categoryMasterService.GetAllTrue();
            return Json(result);
        }
        public IActionResult Add()
        {
            return View();
        }
    }
}
