using FitNass.Data;
using FitNass.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace FitNass.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly FitNassContext _context;

        public HomeController(ILogger<HomeController> logger, FitNassContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
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

        // GET: HomeController
        [Route("/{link}")]
        public async Task<IActionResult> ProfileAsync(string link)
        {
            if (await _context.Users.FirstOrDefaultAsync(m => m.Link == link) != null)
            {
                ViewData["link"] = link;
                return View("~/Views/Profile/index.cshtml");
            }
            return NotFound();
        }

    }
}
