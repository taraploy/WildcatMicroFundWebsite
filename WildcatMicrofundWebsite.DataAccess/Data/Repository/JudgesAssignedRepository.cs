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
    public class JudgesAssignedRepository : Repository<JudgesAssigned>, IJudgesAssignedRepository
    {
        private readonly ApplicationDbContext _db;
       
        public JudgesAssignedRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public IEnumerable<SelectListItem> GetJudgesAssignedListForDropDown()
        {
            return _db.Application.Select(i => new SelectListItem()
            {
                //************ If we want to add other columns to the list.
                Value = i.Id.ToString()
            });
        }

        public void Update(JudgesAssigned judgesAssigned)
        {
            var judgesAssignedFromDb = _db.JudgesAssigned.FirstOrDefault(m => m.JudgesAssignedId == judgesAssigned.JudgesAssignedId);

            judgesAssignedFromDb.JudgesAssignedId = judgesAssigned.JudgesAssignedId;
            judgesAssignedFromDb.PitchEventsId = judgesAssigned.PitchEventsId;
            judgesAssignedFromDb.SystemUserId = judgesAssigned.SystemUserId;

            _db.SaveChanges();
        }
    }
}
