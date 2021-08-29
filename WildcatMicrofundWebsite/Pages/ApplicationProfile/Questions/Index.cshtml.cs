using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WMF.DataAccess.Data.Repository.IRepository;
using WMF.Models;
using WMF.Models.ViewModels;
using WMF.Utility;

namespace WMF.Pages.ApplicationProfile.Questions
{
    public class IndexModel : PageModel
    {
        private readonly IUnitOfWork _unitOfWork;

        public IndexModel(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [BindProperty]
        public List<QuestionResponses> QuestionResponseList { get; set; }
        public QuestionResponses QuestionResponses { get; set; } //techically, since with have two objects we should create a viewmodel.
                                                                 //However, QuestionResponses are used to insert new records and never shown.
 
        public Models.Application Application { get; set; }

        public IActionResult OnGet(int Id)
        {
            QuestionResponseList = new List<QuestionResponses>();
            Application = new Models.Application();

            Application = _unitOfWork.Application.GetFirstOrDefault(a => a.Id == Id);

            IEnumerable<QuestionResponses> responses = _unitOfWork.QuestionResponses.GetAll(r => r.ApplicationId == Id, 
                                                        q => q.OrderBy(q => q.Questions.QuestionOrder), "Questions");

            if (responses.Count() != 0) //responses to this category exisit already
            {
                QuestionResponseList = responses.ToList();
                return Page(); //refresh page call onGet again without id
            }
            else  //we need to insert a list of all the questions for the Status new category with blank responses
            {
                IEnumerable<Models.Questions> questions = _unitOfWork.Questions.GetAll(a => a.QuestionCategoriesId == SD.StatusInProgress || 
                                                a.QuestionCategoriesId == SD.StatusPendingApproval, q => q.OrderBy(q => q.QuestionOrder), null);

                foreach (var question in questions)
                {
                    QuestionResponses = new QuestionResponses
                    {
                        QuestionId = question.Id,
                        ApplicationId = Id,
                        QuestionResponse = null,
                        QuestionResponseDate = DateTime.Now
                    };

                    // add and save for each row                            
                    _unitOfWork.QuestionResponses.Add(QuestionResponses);
                    _unitOfWork.Save();

                }
                //refresh this page passing in the ApplicationId to get the newly inserted blank responses to all the questions with status new
                return RedirectToPage("./Upsert", new { id = QuestionResponses.ApplicationId });
            }
        }

        public ActionResult OnPost(int id)
        {
            Application = _unitOfWork.Application.GetFirstOrDefault(a => a.Id == id);
            Application.StatusId = SD.StatusPendingApproval;
            _unitOfWork.Application.Update(Application);
            _unitOfWork.Save();

            return RedirectToPage("../Home/Index");
        }
    }
}