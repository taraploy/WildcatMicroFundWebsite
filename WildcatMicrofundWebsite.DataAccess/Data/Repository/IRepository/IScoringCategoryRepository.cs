using System;
using System.Collections.Generic;
using System.Text;
using System.Web.Mvc;
using WMF.Models;

namespace WMF.DataAccess.Data.Repository.IRepository
{
    public interface IScoringCategoryRepository : IRepository<ScoringCategory>
    {
        IEnumerable<SelectListItem> GetScoringCategoryListForDropDown();

        void Update(ScoringCategory scoringCategory);
    }
}
