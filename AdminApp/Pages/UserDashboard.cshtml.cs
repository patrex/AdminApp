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
    public class UserDashboardModel : PageModel
    {
        private readonly AppDbContext _db;

        public UserDashboardModel(AppDbContext db)
        {
            _db = db;
        }

        [BindProperty]
        public APINUser CurrentUser { get; set; }

        public IEnumerable<Requests> MyRequests { get; set; }

        [BindProperty]
        public Requests SomeRequest { get; set; }

        [BindProperty]
        public IEnumerable<StoreItems> Items { get; set; }

        public async Task OnGet(string handler, string id)
        {
            if(handler != null)
            {
                CurrentUser = await _db.Users.FindAsync(handler);
                MyRequests = from r in _db.Requests where r.RequesterEmail == handler select r;
            }
            else
            {
                handler = id;
                CurrentUser = await _db.Users.FindAsync(handler);
            }
            // else { RedirectToPage("Error"); }

            Items = await _db.StoreItems.ToListAsync();
        }

        public async Task<IActionResult> OnPostDelete(int reqID, string email)
        {
            CurrentUser = await _db.Users.FindAsync(email);
            SomeRequest = await _db.Requests.FindAsync(reqID);

            if(SomeRequest != null)
            {
                _db.Requests.Remove(SomeRequest);
                await _db.SaveChangesAsync();

                return RedirectToPage("UserDashboard", CurrentUser.eMail);
            }

            return NotFound();
        }
    }
}