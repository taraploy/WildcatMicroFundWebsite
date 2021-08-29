using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WMF.DataAccess.Data.Repository.IRepository;

namespace WMF.Controllers
{
    [Route("api/[controller])")]

    [ApiController]

    public class ApplicationController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public ApplicationController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        [Route("UpdateStatus")]
        public IActionResult UpdateStatus(int ApplicationId, int StatusId)
        {
            var Application = _unitOfWork.Application.Get(ApplicationId);


            _unitOfWork.Application.Update(Application);

            return Ok();

        }
    }
}
