using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WMF.DataAccess.Data.Repository.IRepository;
using WMF.Models;
using WMF.Data;
using System.Linq;

namespace WMF.DataAccess.Data.Repository
{
    public class AwardHistoryRepository : Repository<AwardHistory>, IAwardHistoryRepository
    {
        private readonly ApplicationDbContext _db;

        public AwardHistoryRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public IEnumerable<SelectListItem> GetAwardHistoryListForDropDown()
        {
            return _db.AwardHistory.Select(i => new SelectListItem()
            {                
                Value = i.Id.ToString()
            });
        }

        public void Update(AwardHistory AwardHistory)
        {
            var AwardHistoryFromDB = _db.AwardHistory.FirstOrDefault(s => s.Id == AwardHistory.Id);
             
            AwardHistoryFromDB.AwardDate = AwardHistory.AwardDate;
            AwardHistoryFromDB.AwardAmount = AwardHistory.AwardAmount;
            AwardHistoryFromDB.AwardAgreement = AwardHistory.AwardAgreement;
            AwardHistoryFromDB.ReqNumber = AwardHistory.ReqNumber;
            AwardHistoryFromDB.MailDate = AwardHistory.MailDate;
            AwardHistoryFromDB.Provider = AwardHistory.Provider;
            AwardHistoryFromDB.AwardType = AwardHistory.AwardType;
            AwardHistoryFromDB.Comments = AwardHistory.Comments;                   

            _db.SaveChanges();
        }

    }
}
