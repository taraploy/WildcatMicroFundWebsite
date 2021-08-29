using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WMF.DataAccess.Data.Repository.IRepository;
using WMF.Models;

namespace WMF.Pages.UserProfileEdit
{
    public class UpsertModel : PageModel
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly IUnitOfWork _unitOfWork;

        public UpsertModel(IUnitOfWork unitOfWork,
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager)
        {
            _unitOfWork = unitOfWork;
            _userManager = userManager;
            _signInManager = signInManager;
        }
        public string Username { get; set; }

        [TempData]
        public string StatusMessage { get; set; }

        [BindProperty]
        public InputModel Input { get; set; }

        [BindProperty]
        public ApplicationUser applicationUserObj { get; set; }

        public class InputModel
        {
            [Display(Name = "UserName")]
            public string UserName { get; set; }

            [Display(Name = "Phone number")]
            public string PhoneNumber { get; set; }

            [Display(Name = "First Name")]
            public string FirstName { get; set; }

            [Display(Name = "Last Name")]
            public string LastName { get; set; }

            [Display(Name = "Mailing Address")]
            public string Address1 { get; set; }

            [Display(Name = "City")]
            public string City { get; set; }

            [Display(Name = "County")]
            public string County { get; set; }

            [Display(Name = "Zip Code")]
            public string Zip { get; set; }
        }

        private async Task LoadAsync(ApplicationUser user)
        {
            applicationUserObj = _unitOfWork.ApplicationUser.GetFirstOrDefault(a => a.Id == user.Id);
            var userName = await _userManager.GetUserNameAsync(user);
            var phoneNumber = await _userManager.GetPhoneNumberAsync(user);
            string firstName = applicationUserObj.FirstName;
            string lastName = applicationUserObj.LastName;
            string address1 = applicationUserObj.Address;
            string city = applicationUserObj.City;
            string county = applicationUserObj.County;
            string zip = applicationUserObj.Zip;

            Username = userName;

            Input = new InputModel
            {
                PhoneNumber = phoneNumber,
                FirstName = firstName,
                LastName = lastName,
                Address1 = address1,
                City = city,
                County = county,
                Zip = zip
            };
        }

        public async Task<IActionResult> OnGetAsync()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
            }

            applicationUserObj = _unitOfWork.ApplicationUser.GetFirstOrDefault(a => a.Id == user.Id);

            await LoadAsync(user);
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
            }

            if (!ModelState.IsValid)
            {
                await LoadAsync(user);
                return Page();
            }

            var phoneNumber = await _userManager.GetPhoneNumberAsync(user);
            if (Input.PhoneNumber != phoneNumber)
            {
                var setPhoneResult = await _userManager.SetPhoneNumberAsync(user, Input.PhoneNumber);
                if (!setPhoneResult.Succeeded)
                {
                    StatusMessage = "Unexpected error when trying to set phone number.";
                    return RedirectToPage();
                }
            }

            _unitOfWork.ApplicationUser.Update(applicationUserObj);// Update applicationUser fields
            _unitOfWork.Save(); // Save either the addition or update of application

            await _signInManager.RefreshSignInAsync(user);
            StatusMessage = "Your profile has been updated";
            return RedirectToPage("/ApplicationProfile/Home/Index");

        }
    }    
}
