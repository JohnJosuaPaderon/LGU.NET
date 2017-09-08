using Microsoft.AspNetCore.Mvc;

namespace LGU.HumanResource.Web.Controllers
{
    public class PersonalDataSheetController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
