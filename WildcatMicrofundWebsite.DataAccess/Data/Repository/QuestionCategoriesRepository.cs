using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WMF.Data;
using WMF.Models;
using WMF.DataAccess.Data.Repository.IRepository;

namespace WMF.DataAccess.Data.Repository
{
    public class QuestionCategoriesRepository : Repository<QuestionCategories>, IQuestionCategoriesRepository
    {
        private readonly ApplicationDbContext _db;

        public QuestionCategoriesRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public IEnumerable<SelectListItem> GetQuestionCategoryListForDropDown()
        {
            return _db.QuestionCategories.Select(i => new SelectListItem()
            {
                Text = i.QuestionCategory,
                Value = i.Id.ToString()
            });
        }

        public void Update(QuestionCategories questionCategories)
        {
            var QuestionCategoriesFromDB = _db.QuestionCategories.FirstOrDefault(s => s.Id == questionCategories.Id);

            QuestionCategoriesFromDB.Id = questionCategories.Id;
            QuestionCategoriesFromDB.QuestionCategory = questionCategories.QuestionCategory;
            QuestionCategoriesFromDB.EnableDisable = questionCategories.EnableDisable;

            _db.SaveChanges();
        }
    }
}
