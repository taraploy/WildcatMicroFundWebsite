using System;

namespace WMF.DataAccess.Data.Repository.IRepository
{
    public interface IUnitOfWork : IDisposable
    {    
        IApplicationUserRepository ApplicationUser { get; }
        IApplicationRepository Application { get; }
        IAwardHistoryRepository AwardHistory { get; }       
        IFormsControlLookupRepository FormsControlLookup { get; }
        IFormsControlValuesRepository FormsControlValues { get; }
        IJudgesAssignedRepository JudgesAssigned { get; }
        IJudgeScoreCardRepository JudgeScoreCard { get; }       
        IMentorAssignmentRepository MentorAssignment { get; }
        IMentorNotesRepository MentorNotes { get; }
        IPitchEventsRepository PitchEvents { get; }
        IQuestionCategoriesRepository QuestionCategories { get; }
        IQuestionResponsesRepository QuestionResponses { get; }
        IQuestionsRepository Questions { get; }
        IScoringCategoryRepository ScoringCategory { get; }
        IScoringQuestionsRepository ScoringQuestions { get; }
        IStatusRepository Status { get; }     
     
           
        void Save();
    }
}
