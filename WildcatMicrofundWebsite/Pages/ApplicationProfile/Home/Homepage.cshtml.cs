using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WMF.DataAccess.Data.Repository.IRepository;
using WMF.Models;
using WMF.Models.ViewModels;
using WMF.Utility;

namespace WMF.Pages.ApplicationProfile.Home
{
    [Authorize]
    public class HomepageModel : PageModel
    {
        private readonly IUnitOfWork _unitOfWork;

        public ApplicationUser ApplicationUser;

        public List<Models.Application> ListOfApplications { get; set; }

        public IEnumerable<Models.Application> applications { get; set; }
        public List<Models.Application> notifyApplications = new List<Application>();
        public List<Application> ApplicationsToJudge { get; set; }
        public List<PitchEvents> ListOfPitchEvents { get; set; }
        public IdentityUser Identity;

        public HomepageModel(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public void OnGet()
        {
            var claimsIdentity = (ClaimsIdentity)User.Identity;
            var claim = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier);

            ApplicationUser = _unitOfWork.ApplicationUser.GetFirstOrDefault(c => c.Id == claim.Value);

            if (claim != null)
            {
                applications = _unitOfWork.Application.GetAll(c => c.ApplicationUserId == claim.Value);
                foreach (var item in applications)
                {
                    //if (item.StatusDescription == "Returned to Applicant" || item.StatusDescription == "Archived/Rejected/Closed")
                    if (item.StatusId == SD.StatusReturned || item.StatusId == SD.StatusArchivedRejectedClosed || item.StatusId == SD.StatusApproved)
                    {
                        notifyApplications.Add(item);
                    }
                }
            }

            // During the Pitch event
            ApplicationsToJudge = _unitOfWork.Application.GetAll(a => a.StatusId == SD.StatusPitchEventInProgress, a => a.OrderBy(a => a.ApplicationDate), null).ToList();
            //need to check all applications and see if any have a status of "StatusNewBeingJudged" Order by the date and put it into a list
            ListOfApplications = (_unitOfWork.Application.GetAll(a => a.StatusId == SD.StatusPendingApproval, a => a.OrderBy(a => a.ApplicationDate), null)).ToList();

            ListOfPitchEvents = _unitOfWork.PitchEvents.GetAll(p => p.PitchDateTime > DateTime.Now.AddDays(1), p => p.OrderBy(p => p.PitchDateTime), null).ToList();
        }
    }
}