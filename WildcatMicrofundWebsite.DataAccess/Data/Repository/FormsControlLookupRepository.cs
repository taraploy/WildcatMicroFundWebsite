using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using WMF.Data;
using WMF.DataAccess.Data.Repository.IRepository;
using WMF.Models;

namespace WMF.DataAccess.Data.Repository
{
    public class FormsControlLookupRepository : Repository<FormsControlLookup>, IFormsControlLookupRepository
    {
        private readonly ApplicationDbContext _db;

        public FormsControlLookupRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public IEnumerable<SelectListItem> GetFormsControlLookupListForDropDown()
        {
            return _db.FormsControlLookup.Select(i => new SelectListItem()
            {
                Text = i.FormControlType,
                //************ If we want to add other columns to the list.
                Value = i.Id.ToString()
            });
        }

        public void Update(FormsControlLookup formsControlLookup)
        {
            var formControlsLookupfromDB = _db.FormsControlLookup.FirstOrDefault(s => s.Id == formsControlLookup.Id);

            formControlsLookupfromDB.Id = formsControlLookup.Id;
            formControlsLookupfromDB.FormControlType = formsControlLookup.FormControlType;
            formControlsLookupfromDB.FormControlDescription = formsControlLookup.FormControlDescription;

            _db.SaveChanges();
        }
    }
}
