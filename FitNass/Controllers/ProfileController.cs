using FitNass.Data;
using FitNass.Services;
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
        private readonly IUserService _userService;

        public ProfileController(IUserService userService)
        {
            _userService = userService;
        }

        // GET: HomeController
        /*[Route("/Profile/{link}")]*/
        public async Task<IActionResult> IndexAsync(string link)
        {

            if( await _userService.GetUserByLinkAsync(link) != null)
            {
                ViewData["link"] = link;
                return View();
            }
            return NotFound();
        }
    }
}
