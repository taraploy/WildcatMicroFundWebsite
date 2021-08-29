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
    public class QuestionCategoryController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public QuestionCategoryController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public IActionResult Get()
            //get all question categories 
        {
            return Json(new { data = _unitOfWork.QuestionCategories.GetAll() });
        }

        //[HttpDelete("{id}")]
        //public IActionResult Delete(int id)
        //{
        //    var objFromDB = _unitOfWork.QuestionCategories.GetFirstOrDefault(u => u.Id == id);

        //    if (objFromDB == null)
        //    {
        //        return Json(new { sucess = false, message = "Error while deleteing" });
        //    }
        //    _unitOfWork.QuestionCategories.Remove(objFromDB);
        //    _unitOfWork.Save();
        //    return Json(new { success = true, message = "Delete Successful" });
        //}
    }
}
