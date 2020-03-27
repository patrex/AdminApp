using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AdminApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace AdminApp
{
    public class ViewEventsModel : PageModel
    {
        private readonly AppDbContext _db;

        public ViewEventsModel(AppDbContext db)
        {
            _db = db;
        }

        public IEnumerable<AEvent> Events { get; set; }
        public async Task OnGet()
        {
            Events = await _db.Events.ToListAsync();
        }
    }
}