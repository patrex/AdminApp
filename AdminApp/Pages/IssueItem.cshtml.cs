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

        public ItemIssues Issue { get; set; }

        public APINUser Issuer { get; set; }

        public async Task OnGet(string id)
        {
            ApprovedRequests = from ar in _db.Requests where ar.IsApproved select ar;
        }

        public async Task<IActionResult> OnPost(int reqid, string id)
        {
            SomeRequest = await _db.Requests.FindAsync(reqid);

            Issuer = await _db.Users.FindAsync(id);

            Issue = new ItemIssues();

            Issue.RequestId = SomeRequest.RequestId;
            Issue.QuantityIssued = SomeRequest.QuantityRequested;
            Issue.IssuedAt = DateTime.Now;
            Issue.Issuer = Issuer.Fullname;

            SomeRequest.IsServed = true;    //mark request as done

            await _db.Issues.AddAsync(Issue);
            await _db.SaveChangesAsync();

            return RedirectToPage();
        }
    }
}