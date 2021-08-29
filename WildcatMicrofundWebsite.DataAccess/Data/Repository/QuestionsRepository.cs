using System;
using System.Collections.Generic;
using System.Text;
using WMF.Models;
using WMF.DataAccess.Data.Repository.IRepository;
using WMF.Data;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Linq;

namespace WMF.DataAccess.Data.Repository
{
    public class QuestionsRepository : Repository<Questions>, IQuestionsRepository
    {

        private readonly ApplicationDbContext _db;

        public QuestionsRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }
      
        public IEnumerable<SelectListItem> GetQuestionsListForDropDown()
        {
            int categoryId = 4;

            List<SelectListItem> items = new List<SelectListItem>();

            var cols = _db.Questions.ToList().FindAll(x => x.QuestionCategories.Equals(categoryId));

            foreach (var col in cols)
            {
                SelectListItem item = new SelectListItem
                {
                    Text = col.Question,
                    Value = col.Id.ToString()
                };

                items.Add(item);
            }

            return items;
        }

        public IEnumerable<SelectListItem> GetQuestionsTypeListForDropDown()
        {
            return _db.Questions.Select(i => new SelectListItem()
            {               
                Text = i.QuestionType.ToString(),
                Value = i.Id.ToString()
            }) ;
        }

        public void Update(Questions questions)
        {
            var QuestionsFromDB = _db.Questions.FirstOrDefault(s => s.Id == questions.Id);

            QuestionsFromDB.Id = questions.Id;
            QuestionsFromDB.Question = questions.Question;
            QuestionsFromDB.QuestionOrder = questions.QuestionOrder;
            QuestionsFromDB.QuestionType = questions.QuestionType;
            QuestionsFromDB.EnableDisable = questions.EnableDisable;
            QuestionsFromDB.QuestionCategoriesId = questions.QuestionCategoriesId;

            _db.SaveChanges();
        }
    }
}
