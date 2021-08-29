using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WMF.Models;

namespace WMF.DataAccess.Data.Repository.IRepository
{
    public interface IAwardHistoryRepository : IRepository<AwardHistory>
    {

        IEnumerable<SelectListItem> GetAwardHistoryListForDropDown();

        void Update(AwardHistory AwardHistory);


    }
}
