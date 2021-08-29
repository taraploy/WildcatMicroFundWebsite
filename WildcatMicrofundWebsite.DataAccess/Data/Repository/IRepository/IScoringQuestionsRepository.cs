using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WMF.Models;

namespace WMF.DataAccess.Data.Repository.IRepository
{
    public interface IScoringQuestionsRepository : IRepository<ScoringQuestions>
    {
        IEnumerable<SelectListItem> GetScoringQuestionsListForDropDown();

        void Update(ScoringQuestions scoringQuestions);
    }
}
