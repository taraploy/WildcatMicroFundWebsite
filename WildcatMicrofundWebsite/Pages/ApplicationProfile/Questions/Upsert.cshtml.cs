using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WMF.DataAccess.Data.Repository.IRepository;
using WMF.Models;
using WMF.Models.ViewModels;
using WMF.Utility;

namespace WMF.Pages.ApplicationProfile.Questions
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
        public List<QuestionResponses> QuestionResponseList { get; set; } //A list of all the responses from the user


        public void OnGet(int Id)
        {
            QuestionResponseList = new List<QuestionResponses>();

            //gets all the question responses from one Id then orders them by QuestionOrder
            IEnumerable<QuestionResponses> responses = _unitOfWork.QuestionResponses.GetAll(r => r.ApplicationId == Id, q => q.OrderBy(q => q.Questions.QuestionOrder), "Questions");

            if (responses != null) //if there are already responses
            {
                // take the interable list of question responses and turn them into a list and set them to the global binded property
                QuestionResponseList = responses.ToList();
            }
        }

        public ActionResult OnPostBulk(List<QuestionResponses> QuestionResponseList)
        {
            string webRootPath = _hostingEnvironment.WebRootPath;
            var files = HttpContext.Request.Form.Files;


            if (!ModelState.IsValid)
            {
                return Page();
            }

            if (QuestionResponseList.Count == 0)  //means if no questions show up  //here in case backend breaks
            {
                return NotFound();
            }
            else  //update exisiting application
            {
                foreach (var item in QuestionResponseList)
                {
                    if (item.QuestionId == SD.FileUploadQuestions)
                    {
                        var objFromDb = _unitOfWork.QuestionResponses.Get(item.Id);

                        if (files.Count > 0)
                        {
                            // Physically upload and save image
                            string fileName = Guid.NewGuid().ToString();
                            var uploads = Path.Combine(webRootPath, @"prototypeFile");
                            var extension = Path.GetExtension(files[0].FileName);

                            if (item.QuestionResponse == null)
                            {
                                item.QuestionResponse = @"\prototypeFile\" + fileName + extension;
                            }
                            else
                            {

                                var filePath = Path.Combine(webRootPath, item.QuestionResponse.TrimStart('\\'));
                                if (System.IO.File.Exists(filePath))
                                {
                                    System.IO.File.Delete(filePath);
                                }
                                using (var fileStream = new FileStream(Path.Combine(uploads, fileName + extension), FileMode.Create))
                                {
                                    files[0].CopyTo(fileStream);
                                }

                                // save the string data path
                                item.QuestionResponse = @"\prototypeFile\" + fileName + extension;
                            }
                        }
                        _unitOfWork.QuestionResponses.Update(item);
                    }
                    _unitOfWork.QuestionResponses.Update(item);
                }
            }

            // Creating JudgeScoreCards after applicant finishes application
            var marketCard = new JudgeScoreCard()
            {
                JudgeScore = 0,
                JudgesAssignedId = SD.AdminForApplicationJudge,
                ScoringQuestionsId = SD.Market,
                ScoringApplicationId = QuestionResponseList[0].ApplicationId
            };

            var customerCard = new JudgeScoreCard()
            {
                JudgeScore = 0,
                JudgesAssignedId = SD.AdminForApplicationJudge,
                ScoringQuestionsId = SD.CustomersTargetMarket,
                ScoringApplicationId = QuestionResponseList[0].ApplicationId
            };

            var saleCard = new JudgeScoreCard()
            {
                JudgeScore = 0,
                JudgesAssignedId = SD.AdminForApplicationJudge,
                ScoringQuestionsId = SD.Sale,
                ScoringApplicationId = QuestionResponseList[0].ApplicationId
            };

            var competitionCard = new JudgeScoreCard()
            {
                JudgeScore = 0,
                JudgesAssignedId = SD.AdminForApplicationJudge,
                ScoringQuestionsId = SD.Competition,
                ScoringApplicationId = QuestionResponseList[0].ApplicationId
            };

            var teamCard = new JudgeScoreCard()
            {
                JudgeScore = 0,
                JudgesAssignedId = SD.AdminForApplicationJudge,
                ScoringQuestionsId = SD.Team,
                ScoringApplicationId = QuestionResponseList[0].ApplicationId
            };

            _unitOfWork.JudgeScoreCard.Add(marketCard);
            _unitOfWork.JudgeScoreCard.Add(customerCard);
            _unitOfWork.JudgeScoreCard.Add(saleCard);
            _unitOfWork.JudgeScoreCard.Add(competitionCard);
            _unitOfWork.JudgeScoreCard.Add(teamCard);

            _unitOfWork.Save();
            ModelState.Clear();

            return RedirectToPage("./Index", new { id = QuestionResponseList[0].ApplicationId });
        }
    }
}