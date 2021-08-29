using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WMF.Utility;

namespace WMF.Pages
{
    public class IndexModel : PageModel
    {
        public IActionResult OnGet()
        {
            if (User.IsInRole(SD.AdministratorRole))
            {
                return RedirectToPage("/ApplicationProfile/Home/Homepage");
            }
            else if (User.IsInRole(SD.ApplicantRole))
            {
                return RedirectToPage("/ApplicationProfile/Home/Homepage");
            }
            else if (User.IsInRole(SD.JudgeRole))
            {
                return RedirectToPage("/ApplicationProfile/Home/Homepage");
            }
            else if (User.IsInRole(SD.MentorRole))
            {
                return RedirectToPage("/ApplicationProfile/Home/Homepage");
            }
            else if (User.IsInRole(SD.ManagementRole))
            {
                return RedirectToPage("/ApplicationProfile/Home/Homepage");
            }
            else
            {
                return RedirectToPage("/ApplicationProfile/Home/Homepage");
            }
        }
    }
}
