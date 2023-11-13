//=================================
// Copyright (c) Tarteeb LLC.
// Powering True Leadership
//=================================

using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using xChanger.MVC.Models.Orchestrations.Groups;
using xChanger.MVC.Services.Orchestrations;
using xChanger.MVC.Models.Orchestrations.ExternalApplicants;
using xChanger.MVC.Models.Orchestrations.SpreadSheet;
using xChanger.MVC.Models.Foundations.Applicants.Exceptions.Categories;

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
            catch (SpreadSheetOrchestrationValidationException SpreadSheetOrchestrationValidationException)
            {

                return BadRequest(SpreadSheetOrchestrationValidationException.Message + " "
                    + SpreadSheetOrchestrationValidationException.InnerException.Message);
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
            catch (GroupOrchestrationServiceException groupOrchestrationServiceException)
            {
                return BadRequest(groupOrchestrationServiceException.Message + " " +
                    groupOrchestrationServiceException.InnerException.Message);
            }
            catch(ExternalApplicantOrchestrationValidationException applicantOrchestrationValidationException)
            {
                return BadRequest(applicantOrchestrationValidationException.Message + " " +
                    applicantOrchestrationValidationException.InnerException.Message);
            }
            catch(ApplicantOrchestrationDependencyException applicantOrchestrationDependencyException)
            {
                return BadRequest(applicantOrchestrationDependencyException.Message + " " +
                    applicantOrchestrationDependencyException.InnerException.Message);
            }
            catch(ApplicantDependencyValidationException applicantDependencyValidationException)
            {
                return BadRequest(applicantDependencyValidationException.Message + " " +
                    applicantDependencyValidationException.InnerException);
            }
            catch(ApplicantOrchestrationServiceException applicantOrchestrationServiceException)
            {
                return BadRequest(applicantOrchestrationServiceException + " " +
                    applicantOrchestrationServiceException.InnerException);
            }
        }
    }
}
