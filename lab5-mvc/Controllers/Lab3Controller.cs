using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Lab5_MVC.Models;

namespace Lab5_MVC.Controllers
{
    public class Lab3Controller : Controller
    {
        [HttpPost]
        public IActionResult Submit(LabViewModel model)
        {
            model.OutputText = Labs.Lab3(model.InputText);
            return View("Index", model);
        }

        [Authorize]
        public IActionResult Index()
        {
            return View();
        }
    }
}
