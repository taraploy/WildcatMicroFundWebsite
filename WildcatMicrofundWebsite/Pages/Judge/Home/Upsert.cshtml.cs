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

namespace WMF.Pages.Judge.Home
{
    public class UpsertModel : PageModel
    {
        private readonly IUnitOfWork _unitOfWork;

        public UpsertModel(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public Models.Application Application { get; set; } //for the application Id we are tying to scores

        public List<JudgesAssigned> Judge { get; set; }

        [BindProperty]
        public List<JudgeScoreCard> JudgesScoreList { get; set; }//a list of all the scores that will be added after admin scores
                                                                 //if this is the first time then scores and comments are blank

        public int ptsPossible = 0;
        public int ptCnt = 0;
        public int initialPts = 0;

        public IActionResult OnGet(int Id)
        {
            JudgesScoreList = new List<JudgeScoreCard>();
            Judge = new List<JudgesAssigned>();           

            // Getting user that is signed in
            var claimsIdentity = (ClaimsIdentity)User.Identity;
            var claim = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier);

            // Getting JudgeAssigned so we can pass id to JudgeScoreResponses
            Judge = _unitOfWork.JudgesAssigned.GetAll(j => j.SystemUserId == claim.Value, null, null).ToList();

            //getting all judges score to see if its 0 meaning new first time here and if not then we are redisplaying current scores    
            IEnumerable<JudgeScoreCard> JudgeScoreResponses = _unitOfWork.JudgeScoreCard.GetAll(j => j.ScoringApplicationId == Id && 
            Judge.Contains(j.JudgesAssigned), j => j.OrderBy(j => j.ScoringQuestions.ScoringOrder), "ScoringQuestions");

            if (JudgeScoreResponses.Count() != 0) //scores for this application already exist
            {
                // take the interable list of judge score's and turn them into a list and set them to the global binded property
                JudgesScoreList = JudgeScoreResponses.ToList();
            }

            foreach (var item in JudgesScoreList)
            {
                // Checking for these nine categories
                if (item.ScoringQuestionsId == SD.MarketValidation || item.ScoringQuestionsId == SD.Value || item.ScoringQuestionsId == SD.TargetCustomer ||
                    item.ScoringQuestionsId == SD.JudgeCompetition || item.ScoringQuestionsId == SD.Strategy || item.ScoringQuestionsId == SD.FinancialProjection ||
                    item.ScoringQuestionsId == SD.ManagementTeam || item.ScoringQuestionsId == SD.StatusAsk || item.ScoringQuestionsId == SD.OverallPresentation)
                {
                    ptsPossible += item.ScoringQuestions.MaxScore;
                }
                initialPts += (int)item.JudgeScore;
            }

            ptCnt = JudgesScoreList.Count;

            return Page();
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

            return RedirectToPage("./Index", new { id = JudgesScoreList[0].ScoringQuestionsId });
        }
    }
}