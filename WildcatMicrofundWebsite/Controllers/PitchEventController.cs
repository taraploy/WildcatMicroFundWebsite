using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using WMF.DataAccess.Data.Repository.IRepository;

namespace WMF.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PitchEventController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public PitchEventController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Json(new { data = _unitOfWork.PitchEvents.GetAll(null, a => a.OrderBy(a => a.PitchDateTime), "Status") });
        }
    }
}