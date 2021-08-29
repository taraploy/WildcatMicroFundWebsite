using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WMF.DataAccess.Data.Repository.IRepository;

namespace WMF.Pages.Admin.QuestionCategory
{
    public class UpsertModel : PageModel
    {
        private readonly IUnitOfWork _unitOfWork;

        public UpsertModel(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [BindProperty]
        public Models.QuestionCategories QuestionCategoriesObj { get; set; }

        public IActionResult OnGet(int? id)//ID is optional
        {
            QuestionCategoriesObj = new Models.QuestionCategories();

            if (id != null)//meaning we have an acutal category for that id then we return it.
            {
                QuestionCategoriesObj = _unitOfWork.QuestionCategories.GetFirstOrDefault(u => u.Id == id);
                if (QuestionCategoriesObj == null)
                {
                    return NotFound();
                }
            }
            return Page();
        }
        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            if (QuestionCategoriesObj.Id == 0)
            {
                _unitOfWork.QuestionCategories.Add(QuestionCategoriesObj);
            }
            else
            {
                _unitOfWork.QuestionCategories.Update(QuestionCategoriesObj);
            }
            _unitOfWork.Save();
            return RedirectToPage("./Index");

        }
    }
}