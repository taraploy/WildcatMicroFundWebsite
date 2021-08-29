using Microsoft.AspNetCore.Mvc;
using WMF.DataAccess.Data.Repository.IRepository;

namespace WMF.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuestionController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public QuestionController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public IActionResult Get()
        {
            // return all questions and inlcude questionscategories
            return Json(new { data = _unitOfWork.Questions.GetAll(null, null, "QuestionCategories") });
        }

        //[HttpDelete("{id}")]
        //public IActionResult Delete(int id)
        //{
        //    var objFromDB = _unitOfWork.Questions.GetFirstOrDefault(u => u.Id == id);

        //    if (objFromDB == null)
        //    {
        //        return Json(new { sucess = false, message = "Error while deleting" });
        //    }

        //    _unitOfWork.Questions.Remove(objFromDB);

        //    _unitOfWork.Save();

        //    return Json(new { success = true, message = "Delete Successful" });
        //}
    }
}