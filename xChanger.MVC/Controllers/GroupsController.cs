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
using xChanger.MVC.Models.Foundations.Applicants;
using xChanger.MVC.Services.Orchestrations;
using Group = xChanger.MVC.Models.Foundations.Groups.Group;

namespace xChanger.MVC.Controllers
{
    public class GroupsController : Controller
    {
        private readonly IOrchestrationService orchestrationService;
        private readonly IWebHostEnvironment _hostingEnvironment;
        public GroupsController(IOrchestrationService orchestrationService, IWebHostEnvironment hostingEnvironment)
        {
            this.orchestrationService = orchestrationService;
            _hostingEnvironment = hostingEnvironment;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult ShowGroups()
        {
            if (WC.IsLogin is false)
                return RedirectToPage("/Account/Login", new { area = "Identity" });

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

        [HttpGet]
        public IActionResult Download()
        {
            string name = orchestrationService.GroupGetDownloadedFileName();
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

        public IActionResult SearchGroups(string str)
        {
            var Allgroups = orchestrationService.RetrieveAllGroups();

            if (string.IsNullOrWhiteSpace(str))
                return View("ShowGroups", Allgroups);

            IQueryable<Group> groups =
                Allgroups.Where(app => app.GroupName.ToLower().Contains(str.ToLower()));

            return View("ShowGroups", groups);
        }
    }

}
