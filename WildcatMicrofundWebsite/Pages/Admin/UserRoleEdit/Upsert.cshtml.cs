using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.Extensions.Logging;
using WMF.Areas.Identity.Pages.Account;
using WMF.Models;
using WMF.Utility;

namespace WMF.Pages.Admin.UserRoleEdit
{
    public class UpsertModel : PageModel
    {
        
        private readonly Microsoft.AspNetCore.Identity.UserManager<ApplicationUser> _userManager;
        private readonly ILogger<RegisterModel> _logger;
        private readonly IEmailSender _emailSender;
        private readonly Microsoft.AspNetCore.Identity.RoleManager<IdentityRole> _roleManager;

        public UpsertModel(
            Microsoft.AspNetCore.Identity.UserManager<ApplicationUser> userManager,         
            ILogger<RegisterModel> logger,
            IEmailSender emailSender,
            Microsoft.AspNetCore.Identity.RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;         
            _logger = logger;
            _emailSender = emailSender;
            _roleManager = roleManager;
        }

        [BindProperty]
        public InputModel Input { get; set; }

        public string ReturnUrl { get; set; }

        public IList<AuthenticationScheme> ExternalLogins { get; set; }

        public class InputModel
        {
            [Required]
            public string FirstName { get; set; }
            [Required]
            public string LastName { get; set; }
            [Required]
            public string PhoneNumber { get; set; }

            [Required]
            [EmailAddress]
            [Display(Name = "Email")]
            public string Email { get; set; }

            [Required]
            [StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 6)]
            [DataType(DataType.Password)]
            [Display(Name = "Password")]
            public string Password { get; set; }

            [DataType(DataType.Password)]
            [Display(Name = "Confirm password")]
            [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
            public string ConfirmPassword { get; set; }

            [Required]
            public string Address1 { get; set; }

            [Required]
            public string City { get; set; }

            [Required]
            public string Zip { get; set; }

            [Required]
            public string County { get; set; }
        }

        public async Task OnGetAsync(string returnUrl = null)
        {
            ReturnUrl = returnUrl;           
        }

        public async Task<IActionResult> OnPostAsync(string returnUrl = null)
        {
            _roleManager.CreateAsync(new IdentityRole(SD.ApplicantRole)).GetAwaiter().GetResult();

            //retrieve the role from the form
            string role = Request.Form["rdUserRole"].ToString();

            //if (role == "") // This is only for the initial login, we are no longer using this after Bob has his login.
            //{ role = SD.AdministratorRole; } //make the first login a manager)

            returnUrl = returnUrl ?? Url.Content("~/"); //null-coalescing assignment operator ??= assigns the value of right-hand operand to its left-hand operand only if the left-hand is nulll

            if (ModelState.IsValid)
            {
                //expand identityuser with applicationuser properties
                var user = new ApplicationUser
                {
                    UserName = Input.Email,                  
                };

                var result = await _userManager.CreateAsync(user, Input.Password); // getting the user's info

                //add the roles to the ASPNET Roles table if they do not exist yet
                if (!await _roleManager.RoleExistsAsync(SD.AdministratorRole))
                {
                    _roleManager.CreateAsync(new IdentityRole(SD.AdministratorRole)).GetAwaiter().GetResult();
                    _roleManager.CreateAsync(new IdentityRole(SD.ApplicantRole)).GetAwaiter().GetResult();
                    _roleManager.CreateAsync(new IdentityRole(SD.JudgeRole)).GetAwaiter().GetResult();
                    _roleManager.CreateAsync(new IdentityRole(SD.MentorRole)).GetAwaiter().GetResult();
                    _roleManager.CreateAsync(new IdentityRole(SD.ManagementRole)).GetAwaiter().GetResult();
                }

                if (result.Succeeded)
                //assign role to the user (from the form radio options available after the first manager is created)
                {
                    switch (role)
                    {
                        case SD.AdministratorRole:
                            await _userManager.AddToRoleAsync(user, SD.AdministratorRole);
                            break;

                        case SD.ManagementRole:
                            await _userManager.AddToRoleAsync(user, SD.ManagementRole);
                            break;
                        case SD.JudgeRole:
                            await _userManager.AddToRoleAsync(user, SD.JudgeRole);
                            break;
                        case SD.MentorRole:
                            await _userManager.AddToRoleAsync(user, SD.MentorRole);
                            break;
                        default:
                            await _userManager.AddToRoleAsync(user, SD.ApplicantRole);
                            break;
                    }

                    //ApplicationUser.Role = user.Role;

                    _logger.LogInformation("User created a new account with password.");

                    var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);

                    code = WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes(code));

                    var callbackUrl = Url.Page(
                        "/Account/ConfirmEmail",
                        pageHandler: null,
                        values: new { area = "Identity", userId = user.Id, code = code, returnUrl = returnUrl },
                        protocol: Request.Scheme);

                    await _emailSender.SendEmailAsync(Input.Email, "Confirm your email",
                       $"Please confirm your account by <a href='{HtmlEncoder.Default.Encode(callbackUrl)}'>clicking here</a>.");

                    if (_userManager.Options.SignIn.RequireConfirmedAccount)
                    {
                        return RedirectToPage("RegisterConfirmation", new { email = Input.Email, returnUrl = returnUrl });
                    }
                    else
                    {                       
                        return LocalRedirect(returnUrl);
                    }

                }

                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }

            }

            // If we got this far, something failed, redisplay form
            return Page();
        }
    }
}