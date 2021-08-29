using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Linq;
using WMF.Data;
using WMF.DataAccess.Data.Repository.IRepository;
using WMF.Models;

namespace WMF.DataAccess.Data.Repository
{
    internal class MentorNotesRepository : Repository<MentorNotes>, IMentorNotesRepository
    {
        private ApplicationDbContext _db;

        public MentorNotesRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public IEnumerable<SelectListItem> GetMentorNotesListForDropDown()
        {
            return _db.Application.Select(i => new SelectListItem()
            {
                //************ If we want to add other columns to the list.
                Value = i.Id.ToString()
            });
        }

        public void Update(MentorNotes mentorNotes)
        {
            var mentorNotesFromDb = _db.MentorNotes.FirstOrDefault(m => m.Id == mentorNotes.Id);

            mentorNotesFromDb.Id = mentorNotes.Id;
            mentorNotesFromDb.NotesDate = mentorNotes.NotesDate;
            mentorNotesFromDb.Notes = mentorNotes.Notes;
            mentorNotes.MentorAssignmentId = mentorNotes.MentorAssignmentId;

            _db.SaveChanges();
        }
    }
}