using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AdminApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace AdminApp.Pages
{
    public class AddParticipantModel : PageModel
    {
        private readonly AppDbContext _db;

        public AddParticipantModel(AppDbContext db)
        {
            _db = db;
        }

        [BindProperty]
        public IEnumerable<APINUser> Users { get; set; }

        [BindProperty]
        public APINEvent SomeEvent { get; set; }

        [BindProperty]
        public APINUser SomeUser { get; set; }

        public OnGoingEvent CurrentEvent { get; set; }

        public async Task OnGet(int id)
        {
            SomeEvent = await _db.Events.FindAsync(id);
            Users = await _db.Users.ToListAsync();
        }

        public async Task<IActionResult> OnPost()
        {
            if (ModelState.IsValid)
            {
                var someEvent = await _db.Events.FindAsync(SomeEvent.Id);
                var someUser = await _db.Users.FindAsync(SomeUser.eMail);

                CurrentEvent.EventID = SomeEvent.Id;
                CurrentEvent.UserID = SomeUser.eMail;

                await _db.ConfirmedEvents.AddAsync(CurrentEvent);
                await _db.SaveChangesAsync();

                return RedirectToPage("Index");
            }
            else
            {
                return Page();
            }
        }
    }
}