using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WMF.DataAccess.Data.Repository.IRepository;
using Microsoft.AspNetCore.Identity;
using WMF.Models;
using WMF.Utility;

namespace WMF.Pages.Admin.PitchEvent
{
    public class UpsertModel : PageModel
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly UserManager<ApplicationUser> _userManager;
        public List<Application> ListOfApplications;
        public List<Application> ApplicationsInEvent; //applications in event 
        public IEnumerable<JudgeScoreCard> ScoreCards;
        public List<ScoringCategory> ScoringCategories;
        public string today;

        [BindProperty]
        public List<string> AreChecked { get; set; }//judges
        [BindProperty]
        public List<int> IsChecked { get; set; }//applications

        public UpsertModel(IUnitOfWork unitOfWork, UserManager<ApplicationUser> userManager)
        {
            _unitOfWork = unitOfWork;
            _userManager = userManager;
        }

        [BindProperty]
        public Models.PitchEvents PitchEventsObj { get; set; }
        public List<ApplicationUser> JudgeList { get; set; }
        public IEnumerable<JudgesAssigned> JudgesAssigned { get; set; }
        public List<string> JudgesAssignedIds;
        public List<Status> statuses;

        public async Task OnGetAsync(int? id)//ID is optional
        {
            //get statuses for just pitch events
            today = DateTime.Now.ToString("MM-dd-yyyy");
            statuses = (_unitOfWork.Status.GetAll(u => u.Id >= 20)).ToList();
            ListOfApplications = new List<Application>();
            ApplicationsInEvent = new List<Application>();
            ListOfApplications = (_unitOfWork.Application.GetAll(a => a.StatusId == SD.StatusApproved, a => a.OrderBy(a => a.ApplicationDate), null)).ToList();
            PitchEventsObj = new Models.PitchEvents();
            JudgeList = (List<ApplicationUser>)await _userManager.GetUsersInRoleAsync("Judge");
            JudgesAssignedIds = new List<string>();
            if (id != null)//meaning we have an existing event
            {
                JudgesAssigned = _unitOfWork.JudgesAssigned.GetAll(u => u.PitchEventsId == id);
                foreach (var judge in JudgesAssigned)
                {
                    JudgesAssignedIds.Add(judge.SystemUserId);
                }

                //get applications where there are scorecards linked to this pitch event
                var cards = new List<JudgeScoreCard>();
                foreach (var judge in JudgesAssigned)
                {
                    cards = _unitOfWork.JudgeScoreCard.GetAll(u => u.JudgesAssignedId == judge.JudgesAssignedId).ToList();
                    foreach (var card in cards)
                    {
                        var applic = _unitOfWork.Application.GetFirstOrDefault(u => u.Id == card.ScoringApplicationId);
                        if (ListOfApplications.Contains(applic) == false)
                        {
                            ApplicationsInEvent.Add(applic);
                            ListOfApplications.Add(applic);
                        }
                    }
                }

                PitchEventsObj = _unitOfWork.PitchEvents.GetFirstOrDefault(u => u.Id == id);
            }
            else
            {
                ListOfApplications = (_unitOfWork.Application.GetAll(a => a.StatusId == SD.StatusApproved, a => a.OrderBy(a => a.ApplicationDate), null)).ToList();
            }
        }

        public async Task<IActionResult> OnPostAsync()
        {
            bool newEvent = false;
            if (!ModelState.IsValid)
            {
                return Page();
            }

            if (PitchEventsObj.Id == 0)
            {
                _unitOfWork.PitchEvents.Add(PitchEventsObj);
                newEvent = true;
            }
            else
            {
                _unitOfWork.PitchEvents.Update(PitchEventsObj);
            }

            _unitOfWork.Save();

            ListOfApplications = new List<Application>();
            //6

            ScoringCategories = (_unitOfWork.ScoringCategory.GetAll(u => u.ScoreCategory == "Pitch Judge")).ToList();
            ScoringCategories = (ScoringCategories.Where(u => u.EnableDisable == true)).ToList();
            JudgeList = (List<ApplicationUser>)await _userManager.GetUsersInRoleAsync("Judge");
            JudgesAssigned = _unitOfWork.JudgesAssigned.GetAll(u => u.PitchEventsId == PitchEventsObj.Id);
            JudgesAssignedIds = new List<string>();
            foreach (var judge in JudgesAssigned)
            {
                JudgesAssignedIds.Add(judge.SystemUserId);
            }

            ListOfApplications.Clear();
            foreach (var item in IsChecked)
            {
                ListOfApplications.Add(_unitOfWork.Application.GetFirstOrDefault(u => u.Id == item));
            }

            if (newEvent != true)
            {
                ApplicationsInEvent = new List<Application>();
                var cards = new List<JudgeScoreCard>();
                foreach (var judge in JudgesAssigned)
                {
                    cards = _unitOfWork.JudgeScoreCard.GetAll(u => u.JudgesAssignedId == judge.JudgesAssignedId).ToList();
                    foreach (var card in cards)
                    {
                        var applic = _unitOfWork.Application.GetFirstOrDefault(u => u.Id == card.ScoringApplicationId);
                        if (ApplicationsInEvent.Contains(applic) == false)
                        {
                            ApplicationsInEvent.Add(applic);
                        }
                    }
                }

                //delete scorecards from unchecked applications then change status back to 6
                foreach (var appl in ApplicationsInEvent)
                {
                    if (ListOfApplications.Contains(appl) == false)
                    {
                        var crdsToRemove = _unitOfWork.JudgeScoreCard.GetAll(u => u.ScoringApplicationId == appl.Id);
                        _unitOfWork.JudgeScoreCard.RemoveRange(crdsToRemove);
                        appl.StatusId = SD.StatusApproved;
                        appl.StatusDescription = SD.StatusApproved.ToString();
                        _unitOfWork.Save();
                    }
                }
            }

            foreach (var judge in JudgeList)
            {
                //check if box is checked for judge
                if (AreChecked.Contains(judge.Id))
                {
                    //check if any judges are assigned to this event
                    if (JudgesAssignedIds != null)
                    {
                        //check if judgesassigned exists already
                        if (JudgesAssignedIds.Contains(judge.Id))
                        {
                            //check if new application checked then create new score cards
                            foreach (var appl in ListOfApplications)
                            {
                                if (ApplicationsInEvent.Contains(appl) == false)
                                {
                                    var judgeAssignedTmp = _unitOfWork.JudgesAssigned.GetAll(u => u.SystemUserId == judge.Id);
                                    var addToJudgeAssigned = judgeAssignedTmp.FirstOrDefault(u => u.PitchEventsId == PitchEventsObj.Id);

                                    foreach (var cat in ScoringCategories)
                                    {
                                        var newCard = new JudgeScoreCard
                                        {
                                            JudgesAssignedId = addToJudgeAssigned.JudgesAssignedId,
                                            ScoringQuestionsId = cat.ScoringQuestionsId,
                                            ScoringApplicationId = appl.Id
                                        };
                                        _unitOfWork.JudgeScoreCard.Add(newCard);
                                        _unitOfWork.Save();
                                    }
                                    appl.StatusId = SD.StatusPitchEventScheduled;
                                    appl.StatusDescription = SD.StatusPitchEventScheduled.ToString();
                                    _unitOfWork.Save();
                                }
                            }

                        }
                        else
                        {
                            //add to database
                            var tmp = new JudgesAssigned();
                            tmp.PitchEventsId = PitchEventsObj.Id;
                            tmp.SystemUserId = judge.Id;
                            _unitOfWork.JudgesAssigned.Add(tmp);
                            _unitOfWork.Save();

                            //check if scorecards for this judge exist, then see if there is a scorecard for this application and each scoring category
                            var assignedTmp = _unitOfWork.JudgesAssigned.GetAll(u => tmp.SystemUserId == u.SystemUserId);
                            assignedTmp = assignedTmp.Where(u => tmp.PitchEventsId == u.PitchEventsId);
                            ScoreCards = _unitOfWork.JudgeScoreCard.GetAll(u => u.JudgesAssigned.SystemUserId == judge.Id);
                            if (ScoreCards != null)
                            {
                                foreach (var app in ListOfApplications)
                                {
                                    foreach (var cat in ScoringCategories)
                                    {
                                        var checkScoreCards = ScoreCards.Where(u => u.ScoringApplicationId == app.Id);
                                        checkScoreCards = checkScoreCards.Where(u => u.ScoringQuestionsId == cat.ScoringQuestionsId);
                                        if (checkScoreCards.Count() == 0 || checkScoreCards == null)
                                        {
                                            //card does not exist create it
                                            var newCard = new JudgeScoreCard
                                            {
                                                JudgesAssignedId = tmp.JudgesAssignedId,
                                                ScoringQuestionsId = cat.ScoringQuestionsId,
                                                ScoringApplicationId = app.Id
                                            };
                                            _unitOfWork.JudgeScoreCard.Add(newCard);
                                            _unitOfWork.Save();
                                        }
                                    }
                                    app.StatusDescription = SD.StatusPitchEventScheduled.ToString();
                                    app.StatusId = SD.StatusPitchEventScheduled;
                                    _unitOfWork.Save();
                                    //CHANGE STATUS OF APPLICATION HERE 20
                                }
                            }
                            else
                            {
                                foreach (var cat in ScoringCategories)
                                {
                                    foreach (var app in ListOfApplications)
                                    {
                                        //card does not exist create it
                                        var newCard = new JudgeScoreCard
                                        {
                                            JudgesAssignedId = tmp.JudgesAssignedId,
                                            ScoringQuestionsId = cat.ScoringQuestionsId,
                                            ScoringApplicationId = app.Id
                                        };
                                        _unitOfWork.JudgeScoreCard.Add(newCard);
                                        _unitOfWork.Save();
                                    }
                                }
                            }
                        }
                    }
                    else
                    {
                        //add to database
                        var tmp = new JudgesAssigned();
                        tmp.PitchEventsId = PitchEventsObj.Id;
                        tmp.SystemUserId = judge.Id;
                        _unitOfWork.JudgesAssigned.Add(tmp);

                        foreach (var cat in ScoringCategories)
                        {
                            foreach (var app in ListOfApplications)
                            {
                                //card does not exist create it
                                var newCard = new JudgeScoreCard
                                {
                                    JudgesAssignedId = tmp.JudgesAssignedId,
                                    ScoringQuestionsId = cat.ScoringQuestionsId,
                                    ScoringApplicationId = app.Id
                                };
                                _unitOfWork.JudgeScoreCard.Add(newCard);
                                _unitOfWork.Save();
                            }
                        }
                    }

                }
                //delete if judge unchecked
                else
                {
                    if (JudgesAssignedIds != null)
                    {
                        if (JudgesAssignedIds.Contains(judge.Id))
                        {
                            IEnumerable<JudgesAssigned> assignedTo = _unitOfWork.JudgesAssigned.GetAll(u => u.SystemUserId == judge.Id);
                            var tmpJdge = assignedTo.FirstOrDefault(u => u.PitchEventsId == PitchEventsObj.Id);
                            ScoreCards = _unitOfWork.JudgeScoreCard.GetAll(u => u.JudgesAssigned.SystemUserId == judge.Id);
                            foreach (var item in ListOfApplications)
                            {
                                ScoreCards = ScoreCards.Where(a => a.ScoringApplicationId == item.Id);
                                var scoreCardToRemove = ScoreCards.FirstOrDefault(a => a.JudgesAssignedId == tmpJdge.JudgesAssignedId);
                                if (scoreCardToRemove != null)
                                {
                                    _unitOfWork.JudgeScoreCard.Remove(scoreCardToRemove.Id);
                                }
                            }

                            _unitOfWork.JudgesAssigned.Remove(tmpJdge);
                        }
                    }
                }
            }

            foreach (var application in ListOfApplications)
            {
                application.StatusId = PitchEventsObj.StatusId;
                application.StatusDescription = PitchEventsObj.StatusId.ToString();
            }

            _unitOfWork.Save();

            return RedirectToPage("./Index");
        }
    }
}