//=================================
// Copyright (c) Tarteeb LLC.
// Powering True Leadership
//=================================

using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using xChanger.MVC.Models.Foundations.Applicants;
using xChanger.MVC.Services.Orchestrations;
using Group = xChanger.MVC.Models.Foundations.Groups.Group;

namespace xChanger.MVC.Controllers
{
    public class GroupsController : Controller
    {
        private readonly IOrchestrationService orchestrationService;
        public GroupsController(IOrchestrationService orchestrationService)
        {
            this.orchestrationService = orchestrationService;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult ShowGroups()
        {
            IQueryable<Group> groups = orchestrationService.RetrieveAllGroups();
            return View(groups);
        }

        [HttpGet]
        public IActionResult EditGroup(Guid id)
        {
            IQueryable<Group> groups = orchestrationService.RetrieveAllGroups();
            Group group = groups.FirstOrDefault(group => group.Id == id);
            return View(group);
        }

        [HttpPost]
        public async ValueTask<IActionResult> EditGroup(Group group)
        {
            await this.orchestrationService.UpdateGroupAsync(group);
            IQueryable<ExternalApplicantModel> applicants = this.orchestrationService.RetrieveAllApplicants();
            foreach (var item in applicants)
            {
                if (item.GroupId == group.Id)
                {
                    item.GroupName = group.GroupName;
                    await this.orchestrationService.UpdateApplicant(item);
                }

            }
            return RedirectToAction(nameof(ShowGroups));
        }
        [HttpGet]
        public async Task<IActionResult> DeleteGroup(Guid id)
        {
            IQueryable<Group> groups = orchestrationService.RetrieveAllGroups();
            Group group = groups.FirstOrDefault(g => g.Id == id);

            IQueryable<ExternalApplicantModel> applicants = this.orchestrationService.
                RetrieveAllApplicants().
                Where(applicant => applicant.GroupId == group.Id);

            foreach (var item in applicants)
            {
                await this.orchestrationService.DeleteApplicantModelAsync(item);
            }
            await orchestrationService.DeleteGroupAsync(group);
            TempData["infoGroupPanel"] = "true";
            return RedirectToAction(nameof(ShowGroups));
        }
    }

}
