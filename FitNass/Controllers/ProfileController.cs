using FitNass.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FitNass.Controllers
{
    public class ProfileController : Controller
    {
        private readonly FitNassContext _userContext;

        public ProfileController(FitNassContext context)
        {
            _userContext = context;
        }

        // GET: HomeController
        /*[Route("/Profile/{link}")]*/
        public async Task<IActionResult> IndexAsync(string link)
        {
            if (await _userContext.Users.FirstOrDefaultAsync(m => m.Link == link) != null)
            {
                ViewData["link"] = link;
                return View();
            }
            return NotFound();
        }
    }
}
