using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Text;
using WMF.Data;
using WMF.DataAccess.Data.Repository.IRepository;
using WMF.Models;
using System.Linq;

namespace WMF.DataAccess.Data.Repository
{
    public class JudgeScoreCardRepository : Repository<JudgeScoreCard>, IJudgeScoreCardRepository
    {
        private readonly ApplicationDbContext _db;

        public JudgeScoreCardRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public IEnumerable<SelectListItem> GetJudgeScoreCardListForDropDown()
        {
            return _db.JudgeScoreCard.Select(i => new SelectListItem()
            {
                //************ If we want to add other columns to the list.
                Value = i.Id.ToString()
            });
        }
       
        public void Update(JudgeScoreCard judgesScoreCard)
        {
            var judgeScoreCardFromDb = _db.JudgeScoreCard.FirstOrDefault(m => m.Id == judgesScoreCard.Id);

            judgeScoreCardFromDb.Id = judgesScoreCard.Id;
            judgeScoreCardFromDb.JudgeScore = judgesScoreCard.JudgeScore;
            judgeScoreCardFromDb.JudgeComment = judgesScoreCard.JudgeComment;
            //judgeScoreCardFromDb.JudgesAssignedId = judgesScoreCard.JudgesAssignedId;
            //judgeScoreCardFromDb.ScoringQuestionsId = judgesScoreCard.ScoringQuestionsId;
            //judgeScoreCardFromDb.ScoringApplicationId = judgesScoreCard.ScoringApplicationId;

            _db.SaveChanges();
        }
    }
}
