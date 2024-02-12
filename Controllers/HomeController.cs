using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using programmeringmed.Net3.Data;
using programmeringmed.Net3.Models;

namespace programmeringmed.Net3.Controllers
{
    public class HomeController : Controller
    {
        // GET: /Home/
        public IActionResult Index()
        {
            return View();
        }

        // GET: /Home/About
        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        // GET: /Home/Contact
        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }
    }
}