using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WMF.Pages.Admin.QuestionCategory
{
    //because we are using the ajax to populate the table using data in the form of a json string we do not have use for this page.
    public class IndexModel : PageModel
    {
        public void OnGet()
        {
        }
    }
}