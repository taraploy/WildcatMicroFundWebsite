using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WMF.DataAccess.Data.Repository.IRepository;
using WMF.Models;

namespace WMF.Pages.Admin.RackAndStack
{
    public class DetailsModel : PageModel
    {
        private readonly IUnitOfWork _unitOfWork;
        public IEnumerable<JudgesAssigned> AssignedTo;
        public List<JudgeScoreCard> scoreCards;
        public List<string> assignedNames;
        public Status statusDescription;
        public List<Application> ListOfApplications;
        public List<ScoringCategory> ScoringCategories;
        public List<ScoringQuestions> ScoringQuestions;
        public List<JudgeScoreCard> JudgeScoreCards;
        public List<JudgeAndScore> judgeAndScores;


        public struct JudgeAndScore
        {
            public string name;
            public float score;
            public int applicationId;
            public int questionId;
        }

        public DetailsModel(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [BindProperty]
        public Models.PitchEvents PitchEventsObj { get; set; }

        public IActionResult OnGet(int? id)//ID is optional
        {
            PitchEventsObj = new Models.PitchEvents();
            assignedNames = new List<string>();
            ScoringCategories = new List<ScoringCategory>();
            ScoringQuestions = new List<ScoringQuestions>();
            JudgeScoreCards = new List<JudgeScoreCard>();
            judgeAndScores = new List<JudgeAndScore>();

            if (id != null)
            {
                ScoringCategories = (_unitOfWork.ScoringCategory.GetAll(u => u.ScoreCategory == "Pitch Judge")).ToList();
                ScoringCategories = (ScoringCategories.Where(u => u.EnableDisable == true)).ToList();

                foreach(var cat in ScoringCategories)
                {
                    var tmp = _unitOfWork.ScoringQuestions.GetFirstOrDefault(u => u.ScoringQuestionId == cat.ScoringQuestionsId);
                    ScoringQuestions.Add(tmp);
                }

                AssignedTo = _unitOfWork.JudgesAssigned.GetAll(u => u.PitchEventsId == id);
                foreach(var judge in AssignedTo)
                {
                    JudgeScoreCards.AddRange(_unitOfWork.JudgeScoreCard.GetAll(u => u.JudgesAssignedId == judge.JudgesAssignedId));
                }
                PitchEventsObj = _unitOfWork.PitchEvents.GetFirstOrDefault(u => u.Id == id);
                ListOfApplications = new List<Application>();
                var cards = new List<JudgeScoreCard>();
                foreach (var judge in AssignedTo)
                {
                    var tmp = _unitOfWork.ApplicationUser.GetFirstOrDefault(u => u.Id == judge.SystemUserId);
                    assignedNames.Add(tmp.FullName);

                    var scorecards = _unitOfWork.JudgeScoreCard.GetAll(u => u.JudgesAssignedId == judge.JudgesAssignedId);
                    
                    foreach(var sc in scorecards)
                    {
                       JudgeAndScore jas;
                       jas.applicationId = sc.ScoringApplicationId;
                       jas.name = tmp.FullName;
                       jas.score = sc.JudgeScore;
                       jas.questionId = sc.ScoringQuestionsId;

                       judgeAndScores.Add(jas);
                    }

                    cards = _unitOfWork.JudgeScoreCard.GetAll(u => u.JudgesAssignedId == judge.JudgesAssignedId).ToList();
                    foreach (var card in cards)
                    {
                        var applic = _unitOfWork.Application.GetFirstOrDefault(u => u.Id == card.ScoringApplicationId);
                        if (ListOfApplications.Contains(applic) == false)
                        {
                            ListOfApplications.Add(applic);
                        }
                    }
                }

                if (PitchEventsObj == null)
                {
                    return NotFound();
                }
            }

            return Page();
        }
        public IActionResult OnPost()
        {
            return RedirectToPage("./Index");
        }
    }
}