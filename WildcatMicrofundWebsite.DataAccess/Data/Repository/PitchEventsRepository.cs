using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Linq;
using WMF.Data;
using WMF.DataAccess.Data.Repository.IRepository;
using WMF.Models;

namespace WMF.DataAccess.Data.Repository
{
    internal class PitchEventsRepository : Repository<PitchEvents>, IPitchEventsRepository
    {
        private ApplicationDbContext _db;

        public PitchEventsRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public IEnumerable<SelectListItem> GetPitchEventsListForDropDown()
        {
            return _db.PitchEvents.Select(i => new SelectListItem()
            {
                //************ If we want to add other columns to the list.
                Value = i.Id.ToString()
            });
        }

        public void Update(PitchEvents pitchEvents)
        {
            var pitchEventsFromDb = _db.PitchEvents.FirstOrDefault(m => m.Id == pitchEvents.Id);

            pitchEventsFromDb.Id = pitchEvents.Id;
            pitchEventsFromDb.PitchDateTime = pitchEvents.PitchDateTime;
            pitchEventsFromDb.CashFunds = pitchEvents.CashFunds;
            pitchEventsFromDb.ServiceFunds = pitchEvents.ServiceFunds;
            pitchEventsFromDb.StatusId = pitchEvents.StatusId;

            _db.SaveChanges();
        }
    }
}