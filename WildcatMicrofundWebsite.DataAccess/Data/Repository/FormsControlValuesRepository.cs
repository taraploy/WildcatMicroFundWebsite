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
    public class FormsControlValuesRepository : Repository<FormsControlValues>, IFormsControlValuesRepository
    {
        private readonly ApplicationDbContext _db;

        public FormsControlValuesRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public IEnumerable<SelectListItem> GetFormsControlValuesListForDropDown()
        {
            return _db.FormsControlValues.Select(i => new SelectListItem()
            {

                Text = i.Description,
                //************ If we want to add other columns to the list.
                Value = i.Id.ToString()

            });
        }

        public void Update(FormsControlValues formsControlValues)
        {
            var formControlValuesFromDB = _db.FormsControlValues.FirstOrDefault(s => s.Id == formsControlValues.Id);
            formControlValuesFromDB.Id = formsControlValues.Id;
            formControlValuesFromDB.Description = formsControlValues.Description;
            formControlValuesFromDB.DefaultValue = formsControlValues.DefaultValue;
            formControlValuesFromDB.ValueOrder = formsControlValues.ValueOrder;
            formControlValuesFromDB.FormControlsLookupId = formsControlValues.FormControlsLookupId;

            _db.SaveChanges();
        }
    }
}
