using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Linq;
using WMF.Data;
using WMF.DataAccess.Data.Repository.IRepository;
using WMF.Models;

namespace WMF.DataAccess.Data.Repository
{
    internal class MentorAssignmentRepository : Repository<MentorAssignment>, IMentorAssignmentRepository
    {
        private ApplicationDbContext _db;

        public MentorAssignmentRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public IEnumerable<SelectListItem> GetMentorAssignmentListForDropDown()
        {
            return _db.Application.Select(i => new SelectListItem()
            {
                //************ If we want to add other columns to the list.
                Value = i.Id.ToString()
            });
        }

        public void Update(MentorAssignment mentorAssignment)
        {
            var mentorAssignmentFromDb = _db.MentorAssignment.FirstOrDefault(m => m.Id == mentorAssignment.Id);

            mentorAssignmentFromDb.Id = mentorAssignment.Id;
            mentorAssignmentFromDb.DateAssigned = mentorAssignment.DateAssigned;
            mentorAssignmentFromDb.ApprovedToPitchDate = mentorAssignment.ApprovedToPitchDate;
            mentorAssignmentFromDb.MentorEnabled = mentorAssignment.MentorEnabled;
            mentorAssignmentFromDb.ApplicationId = mentorAssignment.ApplicationId;           

            _db.SaveChanges();
        }
    }
}