//=================================
// Copyright (c) Tarteeb LLC.
// Powering True Leadership
//=================================

using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using xChanger.MVC.Models.Orchestrations.ExternalApplicants.Exceptions;
using xChanger.MVC.Models.Orchestrations.Groups;
using xChanger.MVC.Services.Orchestrations;

namespace xChanger.MVC.Controllers
{
    public class SpreadSheetController : Controller
    {
        private readonly IOrchestrationService orchestrationService;
        public SpreadSheetController(IOrchestrationService orchestrationService)
        {
            this.orchestrationService = orchestrationService;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> GetFile(IFormFile formFile)
        {
            try
            {
                await orchestrationService.ProccesingImportRequest(formFile);
                return RedirectToAction("ShowApplicants", "Applicant");
            }
            catch (ExternalApplicantOrchestrationValidationException externalApplicantOrchestrationValidationException)
            {

                return BadRequest(externalApplicantOrchestrationValidationException.Message + " "
                    + externalApplicantOrchestrationValidationException.InnerException.Message);
            }
            catch (GroupOrchestartionValidationException groupOchrestartionValidationException)
            {
                return BadRequest(groupOchrestartionValidationException.Message + " " +
                    groupOchrestartionValidationException.InnerException.Message);
            }
            catch (GroupOrchestartionDependencyException groupOrchestartionDependencyException)
            {
                return BadRequest(groupOrchestartionDependencyException.Message + " " +
                    groupOrchestartionDependencyException.InnerException.Message);
            }
            catch (GroupOrchestartionDependencyValidationException groupOrchestartionDependencyValidationException)
            {
                return BadRequest(groupOrchestartionDependencyValidationException.Message + " " +
                    groupOrchestartionDependencyValidationException.InnerException.Message);
            }
            //exceptions
            catch (GroupOrchestrationServiceException groupOrchestrationServiceException)
            {
                return BadRequest(groupOrchestrationServiceException.Message + " " +
                    groupOrchestrationServiceException.InnerException.Message);
            }
        }
    }
}
