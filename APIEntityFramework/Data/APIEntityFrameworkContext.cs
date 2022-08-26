using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using APIEntityFramework.Model;

namespace APIEntityFramework.Data
{
    public class APIEntityFrameworkContext : DbContext
    {
        public APIEntityFrameworkContext (DbContextOptions<APIEntityFrameworkContext> options)
            : base(options)
        {
        }

        public DbSet<APIEntityFramework.Model.Student> Student { get; set; } = default!;
    }
}
