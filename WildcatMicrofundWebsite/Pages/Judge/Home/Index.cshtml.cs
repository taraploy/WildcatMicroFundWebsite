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

namespace WMF.Pages.Judge.Home
{
    public class IndexModel : PageModel
    {
        private readonly IUnitOfWork _unitOfWork;

        public List<Application> ApplicationsList { get; set; }

        public List<Application> DisplayApplications { get; set; }

        public List<JudgeScoreCard> JSCList { get; set; }

        public List<JudgesAssigned> Judge { get; set; }

        public IndexModel(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public void OnGet()
        {
            ApplicationsList = new List<Application>();
            DisplayApplications = new List<Application>();
            JSCList = new List<JudgeScoreCard>();
            Judge = new List<JudgesAssigned>();

            // Getting user that is signed in
            var claimsIdentity = (ClaimsIdentity)User.Identity;
            var claim = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier);

            // Getting JudgeAssigned so we can pass id to JudgeScoreResponses
            Judge = _unitOfWork.JudgesAssigned.GetAll(j => j.SystemUserId == claim.Value).ToList();

            JSCList = _unitOfWork.JudgeScoreCard.GetAll(j => Judge.Contains(j.JudgesAssigned), null, "Application").ToList();

            ApplicationsList = _unitOfWork.Application.GetAll(a => a.StatusId == SD.StatusPitchEventInProgress, a => a.OrderBy(a => a.ApplicationDate), null).ToList();

            foreach (var application in ApplicationsList)
            {
                foreach (var judge in JSCList)
                {
                    if (judge.Application == application)
                    {
                        DisplayApplications.Add(application);
                        break;
                    }
                }
            }
        }
    }
}