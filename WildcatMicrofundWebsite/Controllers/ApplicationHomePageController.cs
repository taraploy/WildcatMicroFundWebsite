using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using WMF.DataAccess.Data.Repository.IRepository;

namespace WMF.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApplicationHomePageController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public ApplicationHomePageController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var claimsIdentity = (ClaimsIdentity)User.Identity;
            var claim = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier);

            //get all applications where the user id is the same as the user logged in. inlucde the status table
            return Json(new { data = _unitOfWork.Application.GetAll(c => c.ApplicationUserId == claim.Value, null, "Status") });
        }
    }
}
