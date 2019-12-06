using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using _20191204.Hw.Models;
using Microsoft.AspNetCore.Http;
using _20191204.Hw.DataAcces;

namespace _20191204.Hw.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly PortfolioContext context;

        public HomeController(ILogger<HomeController> logger, PortfolioContext context )
        {
            _logger = logger;
            this.context = context;
        }

        public IActionResult Index()
        {
            var projects = context.Projects.ToList();
            var aboutMe = context.AboutMe.ToList();
            var aboutStudy = context.AboutStudy.ToList().OrderBy(x => x.Year);
            var aboutWork = context.AboutWork.ToList().OrderBy(x => x.Year);
            ViewData["Projects"] = projects;
            ViewData["AboutMe"] = aboutMe;
            ViewData["AboutStudy"] = aboutStudy;
            ViewData["AboutWork"] = aboutWork;
            return View();
        }

       

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
