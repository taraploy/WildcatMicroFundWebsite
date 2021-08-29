using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Linq;
using WMF.Data;
using WMF.DataAccess.Data.Repository.IRepository;
using WMF.Models;

namespace WMF.DataAccess.Data.Repository
{
    internal class ScoringQuestionsRepository : Repository<ScoringQuestions>, IScoringQuestionsRepository
    {
        private ApplicationDbContext _db;

        public ScoringQuestionsRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public IEnumerable<SelectListItem> GetScoringQuestionsListForDropDown()
        {
            return _db.ScoringQuestions.Select(i => new SelectListItem()
            {  
                Text = i.ScoreQuestions,
                Value = i.ScoringQuestionId.ToString()
            });
        }

        public void Update(ScoringQuestions scoringQuestions)
        {
            var scoringQuestionsFromDb = _db.ScoringQuestions.FirstOrDefault(s => s.ScoringQuestionId == scoringQuestions.ScoringQuestionId);

            scoringQuestionsFromDb.ScoringQuestionId = scoringQuestions.ScoringQuestionId;
            scoringQuestionsFromDb.ScoreQuestions = scoringQuestions.ScoreQuestions;
            scoringQuestionsFromDb.MaxScore = scoringQuestions.MaxScore;
            scoringQuestionsFromDb.ScoringOrder = scoringQuestions.ScoringOrder;

            _db.SaveChanges();
        }
    }
}