using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using _20191204.Hw.DataAcces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace _20191204.Hw.Controllers
{
    public class AuthController : Controller
    {
        private readonly PortfolioContext context;

        public AuthController(PortfolioContext context)
        {
            this.context = context;
        }
        public IActionResult Index()
        {
            return View();
        } 

        public void Auth(string password)
        {
            if(password == "ya admin otvechayu")
            {
                HttpContext.Session.SetString("AdminIsActive", "Y");
            }
            HttpContext.Response.Redirect($"/AdminAboutMe/Index");
        }
    }
}