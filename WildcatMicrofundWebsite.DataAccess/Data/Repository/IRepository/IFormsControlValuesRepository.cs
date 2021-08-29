using System;
using System.Collections.Generic;
using System.Text;
using System.Web.Mvc;
using WMF.Models;

namespace WMF.DataAccess.Data.Repository.IRepository
{
    public interface IFormsControlValuesRepository : IRepository<FormsControlValues>
    {

        IEnumerable<SelectListItem> GetFormsControlValuesListForDropDown();

        void Update(FormsControlValues FormsControlValues);
    }
}
