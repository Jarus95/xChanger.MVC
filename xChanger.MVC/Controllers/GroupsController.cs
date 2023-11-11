using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Text.RegularExpressions;
using xChanger.MVC.Services.Orchestrations;

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
            IQueryable<Group> groups=orchestrationService.RetrieveAllApplicants();
            return View(groups);
        }
        
    }
}
