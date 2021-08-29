using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using WMF.DataAccess.Data.Repository.IRepository;
using WMF.Models;
using WMF.Models.ViewModels;
using WMF.Utility;

namespace WMF.Pages.Home.ApplicationProfile
{
    [Authorize]
    public class PageModel : Microsoft.AspNetCore.Mvc.RazorPages.PageModel
    {
        private readonly IUnitOfWork _unitOfWork;

        public PageModel(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [BindProperty]
        public ApplicationUser applicationUserObj { get; set; }

        public Models.Application ApplicationObj { get; set; }
        
        public IActionResult OnGet()
        {
            applicationUserObj = new ApplicationUser() { };            

            //getting the identity of the person logged in 
            var claimsIdentity = (ClaimsIdentity)User.Identity;
            var claim = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier);

            if (claim != null)
            {
                //retrive details of the person logged in
                 applicationUserObj = _unitOfWork.ApplicationUser.GetFirstOrDefault(c => c.Id == claim.Value);                             
            }          

            return Page();//refresh page call onGet again without id
        }
    }
}

