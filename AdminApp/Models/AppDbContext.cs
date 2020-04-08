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
        public DbSet<APINEvent> Events { get; set; }
        public DbSet<APINUser> Users { get; set; }

        public DbSet<OnGoingEvent> ConfirmedEvents { get; set; }

    }
}
