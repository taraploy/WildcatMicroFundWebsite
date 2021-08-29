using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WMF.Models;

namespace WMF.DataAccess.Data.Repository.IRepository
{
    public interface IQuestionCategoriesRepository : IRepository<QuestionCategories>
    {
        IEnumerable<SelectListItem> GetQuestionCategoryListForDropDown();

        void Update(QuestionCategories QuestionCategories);
    }
}