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
    public class ViewRequestsModel : PageModel
    {
        private readonly AppDbContext _db;

        public ViewRequestsModel(AppDbContext db)
        {
            _db = db;
        }

        public IEnumerable<APINUser> AllUsers { get; set; }

        public IEnumerable<Requests> AllRequests { get; set; }

        public APINUser SomeUser { get; set; }

        public Requests SomeRequest { get; set; }

        public async Task OnGet()
        {
            AllRequests = await _db.Requests.ToListAsync();
            AllUsers = await _db.Users.ToListAsync();
        }

        public async Task<IActionResult> OnPostApprove(int id)
        {
            SomeRequest = await _db.Requests.FindAsync(id);
            SomeRequest.IsApproved = true;

            await _db.SaveChangesAsync();

            return RedirectToPage();
        }


    }
}