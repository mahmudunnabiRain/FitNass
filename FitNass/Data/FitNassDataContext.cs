using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using FitNass.Models;

namespace FitNass.Data
{
    public class FitNassDataContext : DbContext
    {
        public FitNassDataContext (DbContextOptions<FitNassDataContext> options)
            : base(options)
        {
        }

        public DbSet<FitNass.Models.Test> Test { get; set; }
    }
}
