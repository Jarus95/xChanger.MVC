//=================================
// Copyright (c) Tarteeb LLC.
// Powering True Leadership
//=================================

using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using xChanger.MVC.Models.Foundations.Applicants;
using xChanger.MVC.Services.Orchestrations;

namespace xChanger.MVC.Controllers
{

    public class ApplicantController : Controller
    {
        private readonly IOrchestrationService orchestrationService;
        private readonly IWebHostEnvironment _hostingEnvironment;

        public ApplicantController(IOrchestrationService orchestrationService, IWebHostEnvironment hostingEnvironment)
        {
            this.orchestrationService = orchestrationService;
            _hostingEnvironment = hostingEnvironment;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult ShowApplicants()
        {
            if(WC.IsLogin is false)
                return RedirectToPage("/Account/Login", new { area = "Identity" });

            IQueryable<ExternalApplicantModel> applicants = orchestrationService.RetrieveAllApplicants();
            return View(applicants);

        }

        [HttpGet]
        public IActionResult EditApplicant(Guid id)
        {
            IQueryable<ExternalApplicantModel> applicants = this.orchestrationService.RetrieveAllApplicants();
            ExternalApplicantModel applicant = applicants.FirstOrDefault(applicant => applicant.Id == id);
            ExternalApplicantViewModel viewModel = new ExternalApplicantViewModel();
            viewModel.ExternalApplicantModel = applicant;
            IQueryable<Models.Foundations.Groups.Group> Groups = this.orchestrationService.RetrieveAllGroups();
            viewModel.SelectListGroups = Groups.Select(group => new SelectListItem
            {
                Text = group.GroupName,
                Value = group.Id.ToString()
            });
            return View(viewModel);
        }

        public IActionResult ShowApplicantsByGroupId(Guid id)
        {
            IQueryable<ExternalApplicantModel> applicants =
                  orchestrationService.RetrieveAllApplicants().
                         Where(applicant => applicant.GroupId == id);

            return View("ShowApplicants", applicants);
        }

        [HttpGet]
        public async Task<IActionResult> DeleteApplicant(Guid id)
        {
            var applicants = orchestrationService.RetrieveAllApplicants();
            ExternalApplicantModel applicant = applicants.FirstOrDefault(s => s.Id == id);
            await orchestrationService.DeleteApplicantModelAsync(applicant);
            TempData["infoApplicantPanel"] = "true";
            return RedirectToAction(nameof(ShowApplicants));

        }
        [HttpPost]
        public async ValueTask<IActionResult> EditApplicant(ExternalApplicantViewModel externalApplicantViewModel)
        {
            ExternalApplicantModel applicant = externalApplicantViewModel.ExternalApplicantModel;
            var groups = this.orchestrationService.RetrieveAllGroups();
            applicant.GroupName = groups.
                Where(groups => groups.Id == applicant.GroupId).
                Select(groups => groups.GroupName).
                FirstOrDefault();
            await this.orchestrationService.UpdateApplicant(applicant);

            return RedirectToAction(nameof(ShowApplicants));
        }

        [HttpGet]
        public IActionResult Download()
        {
            string name = orchestrationService.ApplicantGetDownloadedFileName();
            string fileName = name;
            string wwwrootPath = _hostingEnvironment.WebRootPath;
            string filePath = Path.Combine(wwwrootPath, "data", fileName);

            if (System.IO.File.Exists(filePath))
            {
                var fileStream = new FileStream(filePath, FileMode.Open, FileAccess.Read, FileShare.Read);
                return File(fileStream, "application/octet-stream", fileName);
            }

            return NotFound();

        }

        public IActionResult SearchApplicants(string str)
        {
            var allApplicants = orchestrationService.RetrieveAllApplicants();

            if(string.IsNullOrWhiteSpace(str))
                return View("ShowApplicants", allApplicants);

            IQueryable<ExternalApplicantModel> applicants = 
                allApplicants.Where(app=>app.FirstName.ToLower(). Contains(str.ToLower()) 
                || app.LastName. ToLower().Contains(str.ToLower()));

            return View("ShowApplicants", applicants);
        }
        public IActionResult FilterApplicants(string orderby)
        {
            var allApplicants = orchestrationService.RetrieveAllApplicants();

            switch (orderby)
            {
                case "firstname": allApplicants = allApplicants.OrderBy(a => a.FirstName); break;
                case "lastname":  allApplicants = allApplicants.OrderBy(a => a.LastName); break;
                default: break;
            }
            return View("ShowApplicants", allApplicants);
        }
    }
}
