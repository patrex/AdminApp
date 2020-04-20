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

        [BindProperty]
        public IEnumerable<StoreItems> Items { get; set; }

        public async Task OnGet(string handler, string id)
        {
            
            if(handler != null)
            {
                CurrentUser = await _db.Users.FindAsync(handler);
            }
            else
            {
                handler = id;
                CurrentUser = await _db.Users.FindAsync(handler);
            }
            // else { RedirectToPage("Error"); }

            Items = await _db.StoreItems.ToListAsync();
        }
    }
}