using System;
using System.Collections.Generic;
using System.Text;
using System.Web.Mvc;
using WMF.Models;

namespace WMF.DataAccess.Data.Repository.IRepository
{
    public interface IJudgesAssignedRepository : IRepository<JudgesAssigned>
    {
        IEnumerable<SelectListItem> GetJudgesAssignedListForDropDown();
        void Update(JudgesAssigned judgesAssigned);    
    }
}
