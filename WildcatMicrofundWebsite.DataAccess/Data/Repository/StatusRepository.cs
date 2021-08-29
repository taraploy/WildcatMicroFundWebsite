using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Linq;
using WMF.Data;
using WMF.DataAccess.Data.Repository.IRepository;
using WMF.Models;

namespace WMF.DataAccess.Data.Repository
{
    public class StatusRepository : Repository<Status>, IStatusRepository
    {
        private ApplicationDbContext _db;

        public StatusRepository(ApplicationDbContext db) : base (db)
        {
            _db = db;
        }
        public IEnumerable<SelectListItem> GetStatusListForDropDown()
        {
            return _db.Status.Select(i => new SelectListItem()
            {
                Text = i.StatusDescription,
                Value = i.Id.ToString()
            });
        }

        public void Update(Status status)
        {
            var StatusFromDB = _db.Status.FirstOrDefault(s => s.Id == status.Id);

            StatusFromDB.Id = status.Id;
            StatusFromDB.StatusDescription = status.StatusDescription;

            _db.SaveChanges();
        }

    }
}