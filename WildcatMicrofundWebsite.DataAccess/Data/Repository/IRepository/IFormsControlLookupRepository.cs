using System;
using System.Collections.Generic;
using System.Text;
using System.Web.Mvc;
using WMF.Models;

namespace WMF.DataAccess.Data.Repository.IRepository
{
    public interface IFormsControlLookupRepository : IRepository<FormsControlLookup>
    {

        IEnumerable<SelectListItem> GetFormsControlLookupListForDropDown();

        void Update(FormsControlLookup FormsControlLookup);
    }
}
