using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AdminApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AdminApp.Pages
{
    public class IssueItemModel : PageModel
    {
        private readonly AppDbContext _db;

        public IssueItemModel(AppDbContext db)
        {
            _db = db;
        }

        public IEnumerable<Requests> ApprovedRequests { get; set; }

        public Requests SomeRequest { get; set; }

        public void OnGet()
        {
            ApprovedRequests = from ar in _db.Requests where ar.IsApproved select ar;
        }

        public async Task<IActionResult> OnPost(int id)
        {
            SomeRequest = await _db.Requests.FindAsync(id);

            SomeRequest.IsServed = true;
            await _db.SaveChangesAsync();

            return RedirectToPage();
        }
    }
}