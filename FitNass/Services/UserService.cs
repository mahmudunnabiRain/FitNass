﻿using FitNass.Areas.Identity.Data;
using FitNass.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FitNass.Services
{
    public class UserService : IUserService
    {

        private readonly FitNassContext _context;

        public UserService(FitNassContext context)
        {
            _context = context;
        }


        public async Task<FitNassUser> GetUserByLinkAsync(string link)
        {
            var user = await _context.Users.FirstOrDefaultAsync(m => m.Link == link);
            return user;
        }

        public FitNassUser GetUserByLink(string link)
        {
            var user = _context.Users.FirstOrDefault(m => m.Link == link);
            return user;
        }

        public void SetBiodata(FitNassUser user, string biodata)
        {
            user.Biodata = biodata;
            try
            {
                _context.Update(user);
                _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserExists(user.Id))
                {
                    /*return NotFound();*/

                }
                else
                {
                    throw;
                }
            }
        }

        public bool UserExists(string id)
        {
            return _context.Users.Any(e => e.Id == id);
        }


    }
}
