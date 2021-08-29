using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WMF.Pages.Admin.User
{
    public class PageModel : Microsoft.AspNetCore.Mvc.RazorPages.PageModel
    {    
        public IActionResult OnGet()
        {
            return Page();//refresh page call onGet again without id
        }
    }
}
