using HelloDoc.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Microsoft.EntityFrameworkCore;

namespace HelloDoc.Controllers
{
    public class HomeController : Controller
    {
        //private readonly ILogger<HomeController> _logger;

        private readonly HelloDocContext HelloDoc;

        public HomeController(HelloDocContext HelloDoc)
        {
            this.HelloDoc = HelloDoc;
        }


        //public HomeController(ILogger<HomeController> logger)
        //{
        //    _logger = logger;
        //}

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult SubAreq()
        {

            return View();

        }

        public IActionResult PatientInfo()
        {
            return View();
        }

        [HttpPost]

        public async Task<IActionResult> PatientInfo(User dtail)
        {
            dtail.AspNetUserId = "1";
            await HelloDoc.Users.AddAsync(dtail);
            await HelloDoc.SaveChangesAsync();
            return RedirectToAction("SubAreq");
        }

        public IActionResult famfrdInfo()
        {
            return View();
        }
        public IActionResult ConciergeInfo()
        {
            return View();
        }
        public IActionResult BissunessInfo()
        {
            return View();
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
