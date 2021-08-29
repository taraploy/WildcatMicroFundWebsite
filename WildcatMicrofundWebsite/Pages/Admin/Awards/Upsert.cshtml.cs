using System;
using System.Collections.Generic;
using System.IO;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WMF.DataAccess.Data.Repository.IRepository;
using WMF.Models;
using WMF.Models.ViewModels;
using WMF.Utility;

namespace WMF.Pages.Admin.Awards
{
    public class UpsertModel : PageModel
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IWebHostEnvironment _hostingEnvironment;

        public UpsertModel(IUnitOfWork unitOfWork, IWebHostEnvironment hostingEnvironment)
        {
            _unitOfWork = unitOfWork;
            _hostingEnvironment = hostingEnvironment;
        }

        [BindProperty]
        public AwardsVM awardVMObj { get; set; }

        [BindProperty]
        public int applicationId { get; set; }

        [BindProperty]
        public List<Application> applicationList { get; set; }

        [BindProperty]
        public int? getId { get; set; }

        public IActionResult OnGet(int? id) // Id is optional
        {
            awardVMObj = new AwardsVM
            {
                AwardHistory = new Models.AwardHistory(),
                Application = new Models.Application(),
                ApplicationList = _unitOfWork.Application.GetApplicationListForDropDown()
            };

            // For business names
            applicationList = new List<Application>();
            applicationList = (List<Application>)_unitOfWork.Application.GetAll(a => a.StatusId == SD.StatusPitchOverAward);            

            if (id != null)//if we have an id we populate the obj
            {
                awardVMObj.AwardHistory = _unitOfWork.AwardHistory.GetFirstOrDefault(u => u.Id == id);
                if (awardVMObj.AwardHistory == null)
                {
                    return NotFound();
                }
            }

            return Page();
        }

        public IActionResult OnPost(int? id)
        {
            string webRootPath = _hostingEnvironment.WebRootPath;
            var files = HttpContext.Request.Form.Files;

            if (!ModelState.IsValid)
            {
                return Page();
            }

            if (id == null) // Meaning there is no award for this application
            {
                string fileName = Guid.NewGuid().ToString(); //rename file
                var uploads = Path.Combine(webRootPath, @"images\awards");
                var extension = Path.GetExtension(files[0].FileName);

                using (var fileStream = new FileStream(Path.Combine(uploads, fileName + extension), FileMode.Create))
                {
                    files[0].CopyTo(fileStream);
                }

                //Save the string data path
                awardVMObj.AwardHistory.AwardAgreement = @"\images\awards\" + fileName + extension;
                awardVMObj.AwardHistory.Application = _unitOfWork.Application.GetFirstOrDefault(a => a.Id == applicationId);                

                _unitOfWork.AwardHistory.Add(awardVMObj.AwardHistory);
            }
            else
            {
                var objFromDb = _unitOfWork.AwardHistory.Get(awardVMObj.AwardHistory.Id);
                if (files.Count > 0)
                {
                    // Physically upload and save image
                    string fileName = Guid.NewGuid().ToString();
                    var uploads = Path.Combine(webRootPath, @"images\awards");
                    var extension = Path.GetExtension(files[0].FileName);

                    var filePath = Path.Combine(webRootPath, objFromDb.AwardAgreement.TrimStart('\\'));
                    if (System.IO.File.Exists(filePath))
                    {
                        System.IO.File.Delete(filePath);
                    }
                    using (var fileStream = new FileStream(Path.Combine(uploads, fileName + extension), FileMode.Create))
                    {
                        files[0].CopyTo(fileStream);
                    }

                    // save the string data path
                    awardVMObj.AwardHistory.AwardAgreement = @"\images\awards\" + fileName + extension;
                }
                else
                {
                    awardVMObj.AwardHistory.AwardAgreement = objFromDb.AwardAgreement;
                }

                _unitOfWork.AwardHistory.Update(awardVMObj.AwardHistory);
            }

            _unitOfWork.Save();

            return RedirectToPage("./Index");
        }
    }
}