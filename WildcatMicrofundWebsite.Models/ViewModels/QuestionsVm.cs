using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Text;


namespace WMF.Models.ViewModels
{
    public class QuestionVM
    {
        public Questions Question { get; set; }
        public IEnumerable<SelectListItem> QuestionCategoryList { get; set; }
        public IEnumerable<SelectListItem> QuestionTypeList { get; set; }
    }
}
