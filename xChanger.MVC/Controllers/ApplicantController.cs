//=================================
// Copyright (c) Tarteeb LLC.
// Powering True Leadership
//=================================

using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using xChanger.MVC.Models.Foundations.Applicants;
using xChanger.MVC.Services.Orchestrations;

namespace xChanger.MVC.Controllers
{

    public class ApplicantController : Controller
    {
        private readonly IOrchestrationService orchestrationService;

        public ApplicantController(IOrchestrationService orchestrationService)
        {
            this.orchestrationService = orchestrationService;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult ShowApplicants()
        {
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
    }
}
