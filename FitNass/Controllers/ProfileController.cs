using FitNass.Areas.Identity.Data;
using FitNass.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FitNass.Controllers
{
    [Authorize]
    public class ProfileController : Controller
    {
        private readonly UserManager<FitNassUser> _userManager;
        private readonly FitNassContext _context;

        public ProfileController(UserManager<FitNassUser> UserManager, FitNassContext context)
        {
            _userManager = UserManager;
            _context = context;
        }

        // GET: ProfileController
        [Route("/{link}")]
        public async Task<IActionResult> IndexAsync(string link)
        {
            if(await _context.Users.FirstOrDefaultAsync(m => m.Link == link) != null)
            {
                ViewData["link"] = link;
                return View();
            }
            return NotFound();
        }

    }
}
