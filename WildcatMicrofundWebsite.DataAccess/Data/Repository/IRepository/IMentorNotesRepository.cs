using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WMF.Models;

namespace WMF.DataAccess.Data.Repository.IRepository
{
    public interface IMentorNotesRepository : IRepository<MentorNotes>
    {

        IEnumerable<SelectListItem> GetMentorNotesListForDropDown();

        void Update(MentorNotes mentorNotes);


    }
}
