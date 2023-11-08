using System.Diagnostics;
using Microsoft.AspNetCore.Http;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using xChanger.MVC.Models;
using xChanger.MVC.Models.Orchestrations.ExternalApplicants.Exceptions;
using xChanger.MVC.Models.Orchestrations.Groups;
using xChanger.MVC.Services.Orchestrations;
using System.Linq;
using xChanger.MVC.Models.Foundations.Applicants;

namespace xChanger.MVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IOrchestrationService orchestrationService;
        public HomeController(ILogger<HomeController> logger, IOrchestrationService orchestrationService)
        {
            _logger = logger;
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

                return  RedirectToAction(nameof(ShowApplicants));
            }
            catch (ExternalApplicantOrchestrationValidationException externalApplicantOrchestrationValidationException)
            {

                return BadRequest(externalApplicantOrchestrationValidationException.Message + " "
                    + externalApplicantOrchestrationValidationException.InnerException.Message);
            }
            catch (GroupOchrestartionValidationException groupOchrestartionValidationException)
            {
                return BadRequest(groupOchrestartionValidationException.Message + " " +
                    groupOchrestartionValidationException.InnerException.Message);
            }
            catch (GroupOchrestartionDependencyException groupOchrestartionDependencyException)
            {
                return BadRequest(groupOchrestartionDependencyException.Message + " " +
                    groupOchrestartionDependencyException.InnerException.Message);
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

        public IActionResult ShowApplicants()
        {
            IQueryable<ExternalApplicantModel> applicants = orchestrationService.RetrieveAllApplicants();
            return View(applicants);

        }
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}