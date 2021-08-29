using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WMF.DataAccess.Data.Repository.IRepository;
using WMF.Models.ViewModels;

namespace WMF.Pages.Admin.Questions
{
    public class UpsertModel : PageModel
    {
        private readonly IUnitOfWork _unitOfWork;

        public UpsertModel(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [BindProperty]
        public QuestionVM QuestionObj { get; set; }

        public IActionResult OnGet(int? id)
        {
            QuestionObj = new QuestionVM//creating the view model and setting the lists in the view model to the lists from the unit of work
            {
                Question = new Models.Questions(),
                QuestionCategoryList = _unitOfWork.QuestionCategories.GetQuestionCategoryListForDropDown(),
                QuestionTypeList = _unitOfWork.Questions.GetQuestionsTypeListForDropDown()
            };

            if (id != null)//if we have an id we populate the obj
            {
                QuestionObj.Question = _unitOfWork.Questions.GetFirstOrDefault(u => u.Id == id);
                if (QuestionObj.Question == null)
                {
                    return NotFound();
                }
            }
            return Page();
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)//meaing that all properites have been set and nothing is of null value
            {
                return Page();
            }
            if (QuestionObj.Question.Id == 0)
            {
                _unitOfWork.Questions.Add(QuestionObj.Question);
            }
            else
            {
                _unitOfWork.Questions.Update(QuestionObj.Question);
            }
            _unitOfWork.Save();
            return RedirectToPage("./Index");
        }
    }
}