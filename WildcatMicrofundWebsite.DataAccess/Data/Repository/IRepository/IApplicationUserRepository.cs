using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using WMF.Models;
using WMF.DataAccess.Data.Repository.IRepository;

namespace WMF.DataAccess.Data.Repository.IRepository
{
    public interface IApplicationUserRepository : IRepository<ApplicationUser>
    {
        IEnumerable<SelectListItem> GetApplicationUserListForDropDown();

        void Update(ApplicationUser ApplicationUser);

    }
}