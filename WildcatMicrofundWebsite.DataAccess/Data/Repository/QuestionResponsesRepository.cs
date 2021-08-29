using Microsoft.AspNetCore.Mvc.Rendering;
using WMF.Data;
using WMF.Models;
using WMF.DataAccess.Data.Repository.IRepository;
using System.Collections.Generic;
using System.Linq;

namespace WMF.DataAccess.Data.Repository
{
    public class QuestionResponsesRepository : Repository<QuestionResponses>, IQuestionResponsesRepository
    {
        private readonly ApplicationDbContext _db;

        public QuestionResponsesRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public IEnumerable<SelectListItem> GetQuestionResponsesListForDropDown()
        {
            return _db.QuestionResponses.Select(i => new SelectListItem()
            {                
                Value = i.Id.ToString()
            });
        }       

        public void Update(QuestionResponses questionResponses)
        {
            var questionResponseFromDb = _db.QuestionResponses.FirstOrDefault(r => r.Id == questionResponses.Id);

            questionResponseFromDb.Id = questionResponses.Id;            
            questionResponseFromDb.QuestionResponseDate = System.DateTime.Now;
            questionResponseFromDb.QuestionResponse = questionResponses.QuestionResponse;
            questionResponseFromDb.ApplicationId = questionResponses.ApplicationId;
            questionResponseFromDb.QuestionId = questionResponses.QuestionId;

            _db.QuestionResponses.Update(questionResponseFromDb);

            _db.SaveChanges();
        }      
    }
}