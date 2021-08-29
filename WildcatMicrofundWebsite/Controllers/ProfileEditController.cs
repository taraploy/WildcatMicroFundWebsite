using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WMF.Controllers
{
    public class ProfileEditController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
