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

namespace WMF.Pages.Admin.JudgeApplication
{
    public class UpsertModel : PageModel
    {
        private readonly IUnitOfWork _unitOfWork;

        public UpsertModel(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [BindProperty]
        public List<QuestionResponses> QuestionResponseList { get; set; }//to display all responses needed for judging

        public Models.Application Application { get; set; }//for the application Id we are tying to score

        [BindProperty]
        public List<JudgeScoreCard> JudgesScoreList { get; set; }//a list of all the scores that will be added after admin scores
                                                                 //if this is the first time then scores and comments are blank

        public int ptsPossible = 0;
        public int ptCnt = 0;
        public int initialPts = 0;
        public double minPercentage = 0.5;

        public void OnGet(int Id)
        {
            QuestionResponseList = new List<QuestionResponses>();
            JudgesScoreList = new List<JudgeScoreCard>();

            Application = _unitOfWork.Application.GetFirstOrDefault(a => a.Id == Id);

            IEnumerable<QuestionResponses> responses = _unitOfWork.QuestionResponses.GetAll(r => r.ApplicationId == Id &&
            r.Questions.QuestionCategoriesId == SD.StatusPendingApproval, r => r.OrderBy(r => r.Questions.QuestionOrder), "Questions");

            if (responses != null)
            {
                QuestionResponseList = responses.ToList();
            }

            //getting all judges score to see if its 0 meaning new first time here and if not then we are redisplaying current scores
            IEnumerable<JudgeScoreCard> JudgeScoreResponses = _unitOfWork.JudgeScoreCard.GetAll(j => j.ScoringApplicationId == Id && j.JudgesAssignedId == SD.AdminForApplicationJudge,
                j => j.OrderBy(j => j.ScoringQuestions.ScoringOrder), "ScoringQuestions");

            if (JudgeScoreResponses.Count() != 0) //scores for this application already exist
            {
                // take the interable list of judge score's and turn them into a list and set them to the global binded property
                JudgesScoreList = JudgeScoreResponses.ToList();
            }

            foreach (var item in JudgesScoreList)
            {
                if (item.ScoringQuestionsId <= SD.StatusWithdrawn)
                {
                    ptsPossible += item.ScoringQuestions.MaxScore;
                }
                initialPts += (int)item.JudgeScore;
            }

            ptCnt = JudgesScoreList.Count();
        }

        public ActionResult OnPostBulk(List<JudgeScoreCard> JudgesScoreList)
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            if (JudgesScoreList.Count == 0)
            {
                return NotFound();
            }
            else  //update exisiting
            {
                foreach (var score in JudgesScoreList)
                {
                    _unitOfWork.JudgeScoreCard.Update(score);
                }
                _unitOfWork.Save();

                ModelState.Clear();
            }

            //return RedirectToPage("./Index");
            return RedirectToPage("./Index", new { id = JudgesScoreList[0].ScoringApplicationId });
        }
    }
}