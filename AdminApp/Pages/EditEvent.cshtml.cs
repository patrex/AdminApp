using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AdminApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AdminApp
{
    public class EditEventModel : PageModel
    {
        private readonly AppDbContext _db;

        public EditEventModel(AppDbContext db)
        {
            _db = db;
        }

        [BindProperty]
        public AEvent Event { get; set; }

        public async Task OnGet(string EventId)
        {
            Event = await _db.Events.FindAsync(EventId);
        }
    }
}