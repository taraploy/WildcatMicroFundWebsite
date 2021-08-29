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
    class ScoringCategoryRepository : Repository<ScoringCategory>, IScoringCategoryRepository
    {
        private ApplicationDbContext _db;

        public ScoringCategoryRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public IEnumerable<SelectListItem> GetScoringCategoryListForDropDown()
        {
            return _db.ScoringCategory.Select(i => new SelectListItem()
            {
                Text = i.ScoreCategory,
                Value = i.ScoringCategoryId.ToString()
            });
        }

        public void Update(ScoringCategory scoringCategory)
        {
            var scoringCategoryFromDb = _db.ScoringCategory.FirstOrDefault(s => s.ScoringCategoryId == scoringCategory.ScoringCategoryId);

            scoringCategoryFromDb.ScoringCategoryId = scoringCategory.ScoringCategoryId;
            scoringCategoryFromDb.ScoreCategory = scoringCategory.ScoreCategory;
            scoringCategoryFromDb.EnableDisable = scoringCategory.EnableDisable;


            _db.SaveChanges();

        }
    }
}
