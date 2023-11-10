﻿//=================================
// Copyright (c) Tarteeb LLC.
// Powering True Leadership
//=================================

using System.Linq;
using Microsoft.AspNetCore.Mvc;
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
    }
}