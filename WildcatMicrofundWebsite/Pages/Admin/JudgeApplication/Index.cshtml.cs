using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WMF.DataAccess.Data.Repository.IRepository;
using WMF.Models;
using WMF.Utility;

namespace WMF.Pages.Admin.JudgeApplication
{
    public class IndexModel : PageModel
    {
        private readonly IUnitOfWork _unitOfWork;

        public IndexModel(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [BindProperty]
        public List<QuestionResponses> QuestionResponseList { get; set; }//to display all responses needed for judging

        public Models.Application Application { get; set; }//for the application Id we are tying to the score
        [BindProperty]
        public List<JudgeScoreCard> JudgesScoreList { get; set; }//a list of all the scores that will be added after admin scores if this is the first time then scores and comments are blank

        public ApplicationUser ApplicationUser;//to tie in the admin id thats scoring this application 

        public JudgeScoreCard JudgesScore { get; set; }//this is for when we are adding individual scores wether its new or current scores to the DB      

        public List<JudgesAssigned> JudgesAssigned { get; set; } // This will get the information for each judge assigned to the scoring (mainly for pitch event)

        public int totalPts = 0;
        public int maxPts = 0;
        public double minPercentage = 0.5;

        public IActionResult OnGet(int Id)
        {
            QuestionResponseList = new List<QuestionResponses>();
            JudgesScoreList = new List<JudgeScoreCard>();
            JudgesAssigned = new List<JudgesAssigned>();

            Application = _unitOfWork.Application.GetFirstOrDefault(a => a.Id == Id);

            var claimsIdentity = (ClaimsIdentity)User.Identity;
            var claim = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier);

            if (claim != null)
            {
                //retrive details of the person logged in
                ApplicationUser = _unitOfWork.ApplicationUser.GetFirstOrDefault(c => c.Id == claim.Value);
            }

            //grabbing only the questions that need a score assigned to them
            IEnumerable<QuestionResponses> responses = _unitOfWork.QuestionResponses.GetAll(r => r.ApplicationId == Id && r.Questions.QuestionCategoriesId == SD.StatusPendingApproval,
                                                                                            r => r.OrderBy(r => r.Questions.QuestionOrder), "Questions");

            //we need to load all the questions to the page and responses
            QuestionResponseList = responses.ToList();

            //getting all judges score to see if its 0 meaning new first time here and if not then we are redisplaying current scores
            IEnumerable<JudgeScoreCard> JudgeScoreResponses = _unitOfWork.JudgeScoreCard.GetAll(j => j.Application.Id == Id && j.JudgesAssignedId == SD.AdminForApplicationJudge,
                                                                                                j => j.OrderBy(j => j.ScoringQuestions.ScoringOrder), "ScoringQuestions");

            // Need to populate JudgesAssigned else it's going to pass null objects            
            //JudgesAssigned = _unitOfWork.JudgesAssigned.GetAll(j => j.ApplicationUser.Id == claim.Value, j => j.OrderBy(j => j.Id), null).ToList();

            if (JudgeScoreResponses.Count() != 0) //scores for this application already exist
            {
                // take the interable list of judge score's and turn them into a list and set them to the global binded property
                JudgesScoreList = JudgeScoreResponses.ToList();

                foreach (var item in JudgesScoreList)
                {
                    if (item.ScoringQuestions.ScoringQuestionId <= SD.StatusWithdrawn)
                    {
                        maxPts += item.ScoringQuestions.MaxScore;
                    }
                    totalPts += (int)item.JudgeScore;
                }

                return Page(); //refresh page call onGet again without id
            }
            else  //we need to insert a list of all the judges scores for each availbe scoring category with blank responses
            {
                //getting all the scoring categorys. which is fine for now because they are all related to the intial judge but if we add more
                //we will have to find a way to isolate the specic categories
                IEnumerable<Models.ScoringQuestions> scoringQuestions = _unitOfWork.ScoringQuestions.GetAll(null, s => s.OrderBy(s => s.ScoringOrder));

                foreach (var questions in scoringQuestions)
                {
                    foreach (var judge in JudgesAssigned)
                    {
                        JudgesScore = new JudgeScoreCard
                        {
                            JudgeScore = 0,
                            JudgeComment = "",
                            ScoringQuestionsId = questions.ScoringQuestionId,
                            ScoringApplicationId = Application.Id,
                            JudgesAssignedId = judge.JudgesAssignedId
                        };

                        // add and save for each row                            
                        _unitOfWork.JudgeScoreCard.Add(JudgesScore);
                        _unitOfWork.Save();

                    }
                }

                return RedirectToPage("./Upsert", new { id = Application.Id });
            }
        }

        //OnPost for approve button
        public ActionResult OnPost(int id)
        {
            Application = _unitOfWork.Application.GetFirstOrDefault(a => a.Id == id);
            //If status is approved send it too status approved 
            Application.Comments = Request.Form["Comments"];
            Application.StatusId = SD.StatusApproved;
            _unitOfWork.Application.Update(Application);
            _unitOfWork.Save();

            return RedirectToPage("/ApplicationProfile/Home/Homepage");
        }

        //OnPost for reject button
        public ActionResult OnPostReject(int id)
        {
            Application = _unitOfWork.Application.GetFirstOrDefault(a => a.Id == id);
            //If status is approved send it too status approved 
            Application.Comments = Request.Form["Comments"];
            Application.StatusId = SD.StatusArchivedRejectedClosed;
            _unitOfWork.Application.Update(Application);
            _unitOfWork.Save();

            return RedirectToPage("/ApplicationProfile/Home/Homepage");
        }

        //OnPost for Return Button
        public ActionResult OnPostReturn(int id)
        {
            Application = _unitOfWork.Application.GetFirstOrDefault(a => a.Id == id);
            //If status is approved send it too status approved 
            Application.Comments = Request.Form["Comments"];
            Application.StatusId = SD.StatusReturned;
            _unitOfWork.Application.Update(Application);
            _unitOfWork.Save();

            return RedirectToPage("/ApplicationProfile/Home/Homepage");
        }
    }
}