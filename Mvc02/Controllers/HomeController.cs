using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Mvc02.Models;
using Mvc02.Models.ViewModels;

namespace Mvc02.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }
        public IActionResult Jobs()
        {

            return View();
        }

        public IActionResult Contact()
        {

            return View();

        }

        public IActionResult Confirmation(ContactUsVm contactUs)
        {
            if (!ModelState.IsValid)
            {
                return View("Contact");
            }
            else
            {
                return View("Confirmation");

            }

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
