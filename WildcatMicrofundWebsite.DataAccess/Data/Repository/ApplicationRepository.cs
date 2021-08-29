using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WMF.Data;
using WMF.DataAccess.Data.Repository.IRepository;
using WMF.Models;

namespace WMF.DataAccess.Data.Repository
{
    public class ApplicationRepository : Repository<Application>, IApplicationRepository
    {

        private readonly ApplicationDbContext _db;

        public ApplicationRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public IEnumerable<SelectListItem> GetApplicationListForDropDown()
        {
            return _db.Application.Select(i => new SelectListItem()
            {
                //************ If we want to add other columns to the list.
                Value = i.Id.ToString()
            });
        }

        public void Update(Application Application)
        {
            var ApplicationFromDB = _db.Application.FirstOrDefault(s => s.Id == Application.Id);

            ApplicationFromDB.Id = Application.Id;
            ApplicationFromDB.ApplicationDate = Application.ApplicationDate;           
            ApplicationFromDB.StatusDescription = Application.StatusDescription;
            ApplicationFromDB.BusinessName = Application.BusinessName;
            ApplicationFromDB.Comments = Application.Comments;
            ApplicationFromDB.ApplicationUserId = Application.ApplicationUserId;
            ApplicationFromDB.StatusId = Application.StatusId;

            _db.SaveChanges();
        }
    }
}
