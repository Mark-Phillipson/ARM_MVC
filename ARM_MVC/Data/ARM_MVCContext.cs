#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MSPApplication.Shared.Models;

namespace ARM_MVC.Data
{
    public class ARM_MVCContext : DbContext
    {
        public ARM_MVCContext (DbContextOptions<ARM_MVCContext> options)
            : base(options)
        {
        }

        public DbSet<MSPApplication.Shared.Models.AMenu> AMenu { get; set; }
    }
}
