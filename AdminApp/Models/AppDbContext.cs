using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdminApp.Models
{
    public class AppDbContext: DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options): base(options)
        {

        }

        public DbSet<User> Users { get; set; }
        public DbSet<APINEvent> Events { get; set; }
        public DbSet<StaffList> Staff { get; set; }
    }
}
