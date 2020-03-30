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
        public APINEvent Event { get; set; }

        public async Task OnGet(int id)
        {
            Event = await _db.Events.FindAsync(id);
        }

        public async Task<IActionResult> OnPost()
        {
            if (ModelState.IsValid)
            {
                var someEvent = await _db.Events.FindAsync(Event.Id);

                someEvent.Name = Event.Name;
                someEvent.Venue = Event.Venue;
                someEvent.EventDateTime = Event.EventDateTime;
                someEvent.HostId = Event.HostId;

                await _db.SaveChangesAsync();
                return RedirectToPage("ViewEvents");
            }

            return RedirectToPage();

        }
    }
}