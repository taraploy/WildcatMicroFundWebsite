using WMF.Data;
using WMF.DataAccess.Data.Repository.IRepository;

namespace WMF.DataAccess.Data.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _db;
        public IApplicationRepository Application { get; private set; }
        public IApplicationUserRepository ApplicationUser { get; set; }
        public IAwardHistoryRepository AwardHistory { get; private set; } 
        public IFormsControlLookupRepository FormsControlLookup { get; private set; }
        public IFormsControlValuesRepository FormsControlValues { get; private set; }
        public IJudgesAssignedRepository JudgesAssigned { get; private set; }
        public IJudgeScoreCardRepository JudgeScoreCard { get; private set; }      
        public IMentorAssignmentRepository MentorAssignment { get; private set; }
        public IMentorNotesRepository MentorNotes { get; private set; }
        public IPitchEventsRepository PitchEvents { get; private set; }
        public IQuestionCategoriesRepository QuestionCategories { get; private set; }
        public IQuestionResponsesRepository QuestionResponses { get; private set; }
        public IQuestionsRepository Questions { get; private set; }
        public IScoringCategoryRepository ScoringCategory { get; private set; }
        public IScoringQuestionsRepository ScoringQuestions { get; private set; }
        public IStatusRepository Status { get; private set; }
       
        public UnitOfWork(ApplicationDbContext db)
        {
            _db = db;          
            Application = new ApplicationRepository(_db);
            ApplicationUser = new ApplicationUserRepository(_db);
            AwardHistory = new AwardHistoryRepository(_db);
            FormsControlLookup = new FormsControlLookupRepository(_db);
            FormsControlValues = new FormsControlValuesRepository(_db);
            JudgesAssigned = new JudgesAssignedRepository(_db);
            JudgeScoreCard = new JudgeScoreCardRepository(_db);          
            MentorAssignment = new MentorAssignmentRepository(_db);
            MentorNotes = new MentorNotesRepository(_db);
            PitchEvents = new PitchEventsRepository(_db);
            QuestionCategories = new QuestionCategoriesRepository(_db);
            QuestionResponses = new QuestionResponsesRepository(_db);
            Questions = new QuestionsRepository(_db);
            ScoringCategory = new ScoringCategoryRepository(_db);
            ScoringQuestions = new ScoringQuestionsRepository(_db);
            Status = new StatusRepository(_db);
        }

        public void Dispose()
        {
            _db.Dispose();
        }

        public void Save()
        {
            _db.SaveChanges();
        }
    }
}