using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace WMF.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Models.Application> Application { get; set; }
        public DbSet<Models.ApplicationUser> ApplicationUser { get; set; }
        public DbSet<Models.AwardHistory> AwardHistory { get; set; }   
        public DbSet<Models.FormsControlLookup> FormsControlLookup { get; set; }
        public DbSet<Models.FormsControlValues> FormsControlValues { get; set; }
        public DbSet<Models.JudgesAssigned> JudgesAssigned { get; set; }
        public DbSet<Models.JudgeScoreCard> JudgeScoreCard { get; set; }       
        public DbSet<Models.MentorAssignment> MentorAssignment { get; set; }
        public DbSet<Models.MentorNotes> MentorNotes { get; set; }
        public DbSet<Models.PitchEvents> PitchEvents { get; set; }
        public DbSet<Models.QuestionCategories> QuestionCategories { get; set; }
        public DbSet<Models.QuestionResponses> QuestionResponses { get; set; }
        public DbSet<Models.Questions> Questions { get; set; }
        public DbSet<Models.ScoringCategory> ScoringCategory { get; set; }
        public DbSet<Models.ScoringQuestions> ScoringQuestions { get; set; }      
        public DbSet<Models.Status> Status { get; set; }
    }
}