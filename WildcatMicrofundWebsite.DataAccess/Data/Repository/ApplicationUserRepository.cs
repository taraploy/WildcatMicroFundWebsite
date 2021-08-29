using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WMF.Data;
using WMF.DataAccess.Data.Repository.IRepository;
using WMF.Models;

namespace WMF.DataAccess.Data.Repository
{
    public class ApplicationUserRepository : Repository<ApplicationUser>, IApplicationUserRepository
    {
        private readonly ApplicationDbContext _db;
        
        public ApplicationUserRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public IEnumerable<SelectListItem> GetApplicationUserListForDropDown()
        {
            return _db.ApplicationUser.Select(i => new SelectListItem()
            {
                //************ If we want to add other columns to the list.
                Value = i.Id.ToString()
            });
        }

        public void Update(ApplicationUser ApplicationUser)
        {
            var ApplicationUserFromDB = _db.ApplicationUser.FirstOrDefault(s => s.Id == ApplicationUser.Id);

            ApplicationUserFromDB.Id = ApplicationUser.Id;
            ApplicationUserFromDB.FirstName = ApplicationUser.FirstName;
            ApplicationUserFromDB.LastName = ApplicationUser.LastName;         
            ApplicationUserFromDB.Address = ApplicationUser.Address;          
            ApplicationUserFromDB.City = ApplicationUser.City;
            ApplicationUserFromDB.County = ApplicationUser.County;
            ApplicationUserFromDB.Zip = ApplicationUser.Zip;
            ApplicationUserFromDB.BirthDate = ApplicationUser.BirthDate;
            ApplicationUserFromDB.Gender = ApplicationUser.Gender;
            ApplicationUserFromDB.Race = ApplicationUser.Race;
            ApplicationUserFromDB.Income = ApplicationUser.Income;
            ApplicationUserFromDB.Education = ApplicationUser.Education;
            ApplicationUserFromDB.Residence = ApplicationUser.Residence;
            ApplicationUserFromDB.Military = ApplicationUser.Military;
            ApplicationUserFromDB.UserName = ApplicationUser.UserName;            

            _db.SaveChanges();
        }
    }
}
