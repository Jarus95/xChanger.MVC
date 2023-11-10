using Microsoft.AspNetCore.Mvc;
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
        
    }
}
