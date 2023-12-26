using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Lab5_MVC.Models;

namespace Lab5_MVC.Controllers
{
    public class Lab1Controller : Controller
    {
        [HttpPost]
        public IActionResult Submit(LabViewModel model)
        {
            model.OutputText = Lab5_MVC.Labs.Lab1(model.InputText);
            return View("Index", model);
        }

        [Authorize]
        public IActionResult Index()
        {
            return View();
        }
    }
}
