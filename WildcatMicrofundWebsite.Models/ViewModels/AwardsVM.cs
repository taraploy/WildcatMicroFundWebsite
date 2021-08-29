using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Text;

namespace WMF.Models.ViewModels
{
    public class AwardsVM
    {        
        public AwardHistory AwardHistory { get; set; }
        public Application Application { get; set; }
        public IEnumerable<SelectListItem> AwardHistoryList { get; set; }
        public IEnumerable<SelectListItem> ApplicationList { get; set; }
    }
}
