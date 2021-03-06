using FitNass.Areas.Identity.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FitNass.Services
{
    public interface IUserService
    {
        Task<FitNassUser> GetUserByLinkAsync(string link);

        FitNassUser GetUserByLink(string link);
    }
}
