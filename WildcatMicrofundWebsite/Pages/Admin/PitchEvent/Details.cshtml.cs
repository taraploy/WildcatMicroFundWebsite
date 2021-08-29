using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WMF.DataAccess.Data.Repository.IRepository;
using WMF.Models;

namespace WMF.Pages.Admin.PitchEvent
{
    public class DetailsModel : PageModel
    {
        private readonly IUnitOfWork _unitOfWork;
        public IEnumerable<JudgesAssigned> AssignedTo;
        public List<string> assignedNames;
        public Status statusDescription;
        public List<Application> ListOfApplications;


        public DetailsModel(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [BindProperty]
        public Models.PitchEvents PitchEventsObj { get; set; }

        public IActionResult OnGet(int? id)//ID is optional
        {
            var stats = _unitOfWork.Status.GetAll();
            PitchEventsObj = new Models.PitchEvents();
            assignedNames = new List<string>();

            if (id != null)//meaning we have an acutal category for that id then we return it.
            {

                AssignedTo = _unitOfWork.JudgesAssigned.GetAll(u => u.PitchEventsId == id);
                PitchEventsObj = _unitOfWork.PitchEvents.GetFirstOrDefault(u => u.Id == id);
                statusDescription = stats.FirstOrDefault(u => u.Id == PitchEventsObj.StatusId);
                ListOfApplications = new List<Application>();
                var cards = new List<JudgeScoreCard>();
                foreach (var judge in AssignedTo)
                {
                    var tmp = _unitOfWork.ApplicationUser.GetFirstOrDefault(u => u.Id == judge.SystemUserId);
                    assignedNames.Add(tmp.FullName);


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
            if (!ModelState.IsValid)
            {
                return Page();
            }

            if (PitchEventsObj.Id == 0)
            {
                _unitOfWork.PitchEvents.Add(PitchEventsObj);
            }
            else
            {
                _unitOfWork.PitchEvents.Update(PitchEventsObj);
            }

            _unitOfWork.Save();

            return RedirectToPage("./Index");
        }
    }
}