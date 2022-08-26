using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MVCEntityFramework.Models;

namespace MVCEntityFramework.Data
{
    public class MVCEntityFrameworkContext : DbContext
    {
        public MVCEntityFrameworkContext (DbContextOptions<MVCEntityFrameworkContext> options)
            : base(options)
        {
        }

        public DbSet<MVCEntityFramework.Models.Employee> Employee { get; set; } = default!;
    }
}
