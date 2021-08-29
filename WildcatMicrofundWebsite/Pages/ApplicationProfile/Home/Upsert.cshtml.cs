using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WMF.DataAccess.Data.Repository.IRepository;
using WMF.Models;
using WMF.Models.ViewModels;
using WMF.Utility;

namespace WMF.Pages.ApplicationProfile.Home
{
    public class UpsertModel : PageModel
    {
        private readonly IUnitOfWork _unitOfWork;

        public UpsertModel(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [BindProperty]
        public Models.Application ApplicationObj { get; set; }

        public IActionResult OnGet(int? id)
        {
            ApplicationObj = new Models.Application();

            if (id != null)
            {
                ApplicationObj = _unitOfWork.Application.GetFirstOrDefault(u => u.Id == id); // retrieve details of the application
                if (ApplicationObj == null) // if those details aren't available, return notfound
                {
                    return NotFound();
                }
            }

            return Page();//refresh page call onGet again without id
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid) // If it's not a valid model
            {
                return Page();//refresh page call onGet again without id
            }

            var claimsIdentity = (ClaimsIdentity)User.Identity;
            var claim = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier);

            if (ApplicationObj.Id == 0)// means a new item
            {
                //retrive details of the person logged in
                ApplicationUser applicationUser = _unitOfWork.ApplicationUser.GetFirstOrDefault(c => c.Id == claim.Value);
                ApplicationObj.ApplicationUserId = applicationUser.Id;
                ApplicationObj.ApplicationDate = DateTime.Now;
                ApplicationObj.StatusDescription = "New Application In Progress";
                ApplicationObj.StatusId = 1;

                _unitOfWork.Application.Add(ApplicationObj); // Add application if it's a new item
            }
            else
            {
                _unitOfWork.Application.Update(ApplicationObj); // Update application if it already exists
                return RedirectToPage("/ApplicationProfile/Home/Index"); // Send to the homepage
            }

            _unitOfWork.Save(); // Save either the addition or update of application

            return RedirectToPage("/ApplicationProfile/Questions/Index", new { id = ApplicationObj.Id }); // Send to questions page to begin the application process
        }
    }
}