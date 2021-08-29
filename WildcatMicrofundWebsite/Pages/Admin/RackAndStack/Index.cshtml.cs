using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WMF.DataAccess.Data.Repository.IRepository;
using WMF.Models;
using WMF.Utility;
using System.Security.Claims;

namespace WMF.Pages.Admin.RackAndStack
{
    public class IndexModel : PageModel
    {
        private readonly IUnitOfWork _unitOfWork;

        public IndexModel(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }



        public IEnumerable<PitchEvents> events { get; set; }




        public JudgeScoreCard JudgesScore { get; set; }//this is for when we are adding individual scores wether its new or current scores to the DB      

        [BindProperty]
        public List<JudgeScoreCard> JudgesScoreList { get; set; }//a list of all the scores that will be added after admin scores if this is the first time then scores and comments are blank

        public List<JudgesAssigned> JudgesAssigned { get; set; } // This will get the information for each judge assigned to the scoring (mainly for pitch event)

        [BindProperty]
        public List<JudgeScoreCard> CountScoreList { get; set; }

        public Application application { get; set; }

        [BindProperty]
        public List<Application> applicationList { get; set; }

        public ScoringCategory scoringCategory { get; set; }

        [BindProperty]
        public List<ScoringCategory> ScoringCategories { get; set; }

        public ScoringQuestions scoringQuestion { get; set; }

        [BindProperty]
        public List<int> ScoringQuestionList { get; set; }

        public List<ScoringQuestions> questions { get; set; }
        

        public List<EventScore> scoresApplication { get; set; }




        //public float[] totalScore = { }; // Needs to be in array???????????????
        public float totalScore = 0;
        public float trackScore = 0;
        public int count_judgeScore = 0;
        public int totalPts = 0;
        public int maxPts = 0;
        public double minPercentage = 0.5;



        public struct EventScore
        {
            public string applicationName;
            public float totalScore;
            public int pitchEvent;
        }



        public IActionResult OnGet()
        {
            scoresApplication = new List<EventScore>();
            ScoringQuestionList = new List<int>();
            ScoringCategories = new List<ScoringCategory>();
            ScoringCategories = (_unitOfWork.ScoringCategory.GetAll(u => u.ScoreCategory == "Pitch Judge")).ToList();
            ScoringCategories = (ScoringCategories.Where(u => u.EnableDisable == true)).ToList();

            foreach (var cat in ScoringCategories)
            {
                var tmp = _unitOfWork.ScoringQuestions.GetFirstOrDefault(u => u.ScoringQuestionId == cat.ScoringQuestionsId);
                ScoringQuestionList.Add(tmp.ScoringQuestionId);
            }

            events = _unitOfWork.PitchEvents.GetAll(u => u.StatusId == SD.StatusRackNStackPitch);

            foreach(var ev in events)
            {
                //get all scorecards associated with event
                var associatedJudgesAssigned = _unitOfWork.JudgesAssigned.GetAll(u => u.PitchEventsId == ev.Id);
                var associatedScoreCards = new List<JudgeScoreCard>();
                foreach(var ja in associatedJudgesAssigned)
                {
                    var sc1 = _unitOfWork.JudgeScoreCard.GetAll(u => u.JudgesAssignedId == ja.JudgesAssignedId);
                    sc1 = sc1.Where(u => ScoringQuestionList.Contains(u.ScoringQuestionsId));
                    associatedScoreCards.AddRange(sc1);
                }

                var associatedApplications = new List<Application>();

                //get all applications associated with event
                foreach(var sc in associatedScoreCards)
                {
                    if (associatedApplications.Contains(_unitOfWork.Application.GetFirstOrDefault(u => u.Id == sc.ScoringApplicationId)) == false)
                    {
                        associatedApplications.Add(_unitOfWork.Application.GetFirstOrDefault(u => u.Id == sc.ScoringApplicationId));
                    }
                }

                //create EventScore(struct) for each application
                foreach(var app in associatedApplications)
                {
                    var appScoreCards = associatedScoreCards.Where(u => u.ScoringApplicationId == app.Id);
                    float total = 0;
                    foreach(var asc in appScoreCards)
                    {
                        total += asc.JudgeScore;
                    }
                    EventScore tmp;
                    tmp.applicationName = app.BusinessName;
                    tmp.pitchEvent = ev.Id;
                    tmp.totalScore = total / associatedJudgesAssigned.Count();

                    scoresApplication.Add(tmp);
                }
            }
            return Page();
        }

    }
}