using LGU.HumanResource.Web.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace LGU.HumanResource.Web.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            ViewData["MenuItems"] = new MenuItemModel[]
            {
                new MenuItemModel()
                {
                    Description = "Personal Data Sheet",
                    Controller = "PersonalDataSheet",
                    Action = "Index"
                },
                new MenuItemModel()
                {
                    Description = "Actual Time-Logs",
                }
            };

            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            ViewData["MenuItems"] = new MenuItemModel[]
            {
                new MenuItemModel() {Description = "A" },
                new MenuItemModel() {Description = "B" },
                new MenuItemModel() {Description = "O" },
                new MenuItemModel() {Description = "U" },
                new MenuItemModel() {Description = "T" },
            };

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            ViewData["MenuItems"] = new MenuItemModel[]
            {
                new MenuItemModel() {Description = "C" },
                new MenuItemModel() {Description = "O" },
                new MenuItemModel() {Description = "N" },
                new MenuItemModel() {Description = "T" },
                new MenuItemModel() {Description = "A" },
                new MenuItemModel() {Description = "C" },
                new MenuItemModel() {Description = "T" },
            };

            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
