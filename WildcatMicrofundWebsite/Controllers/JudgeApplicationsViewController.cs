using Microsoft.AspNetCore.Http;
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
    public class JudgeApplicationsViewController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public JudgeApplicationsViewController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public IActionResult Get()
        {
            //getting back all applications ordering it by application date and including the status table. 
            return Json(new { data = _unitOfWork.Application.GetAll(a => a.StatusId == 7, a => a.OrderBy(a => a.ApplicationDate), null) });
        }
    }
}