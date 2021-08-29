using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WMF.DataAccess.Data.Repository.IRepository;
using WMF.Models;
using WMF.Models.ViewModels;
using WMF.Utility;

namespace WMF.Pages.Admin.Awards
{
    public class DetailsModel : PageModel
    {
        private readonly IUnitOfWork _unitOfWork;

        public DetailsModel(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [BindProperty]
        public Models.AwardHistory awardHistory { get; set; }

        [BindProperty]
        public Models.Application application { get; set; }


        public IActionResult OnGet(int Id) // Pass in ID
        {
            awardHistory = new Models.AwardHistory();
            application = new Models.Application();

            // Get the award details of the selected application
            awardHistory = _unitOfWork.AwardHistory.GetFirstOrDefault(a => a.Id == Id);
            // Get Business name of the selected application
            application = _unitOfWork.Application.GetFirstOrDefault(a => a.Id == awardHistory.ApplicationId);

            return Page();
        }
    }
}
