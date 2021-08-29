using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WMF.Models;
using WMF.Models.ViewModels;

namespace WMF.Controllers
{
    public class IndustryDropdownController : Controller
    {
        public IActionResult Index()
        {
            ViewBag.Message = ""; 
            return View();
        }
    }
}
