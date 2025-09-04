using Microsoft.AspNetCore.Mvc;

namespace Insurance.Controllers
{
    public class InsuranceProposal : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
