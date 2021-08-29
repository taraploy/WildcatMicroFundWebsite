using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WMF.DataAccess.Data.Repository.IRepository;

namespace WMF.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AwardsController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public AwardsController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Json(new { data = _unitOfWork.AwardHistory.GetAll(null, null, "Application") });
        }
    }
}