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
    public class AnsweredApplicationQuestionsController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public AnsweredApplicationQuestionsController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public IActionResult Get()
        {
            //getting all question responses and joinning the questions respones
            return Json(new { data = _unitOfWork.QuestionResponses.GetAll(null, null, "QuestionResponses") });
        }

        //[HttpDelete("{id}")]
        //public IActionResult Delete(int id)
        //{
        //    //var objFromDB = _unitOfWork.Questions.GetFirstOrDefault(u => u.Id == id);

        //    //if (objFromDB == null)
        //    //{
        //    //    return Json(new { sucess = false, message = "Error while deleteing" });
        //    //}
        //    //_unitOfWork.Questions.Remove(objFromDB);
        //    //_unitOfWork.Save();

        //    //return Json(new { success = true, message = "Delete Successful" });
        //}
    }
}