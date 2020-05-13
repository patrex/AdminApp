﻿using System;
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

        [BindProperty]
        public Requests SomeRequest { get; set; }

        public ItemIssues Issue { get; set; }

        [BindProperty]
        public APINUser Issuer { get; set; }

        [BindProperty]
        public StoreItems SomeItem { get; set; }

        public async Task OnGet(string id)
        {
            ApprovedRequests = from ar in _db.Requests where ar.IsApproved && !ar.IsServed select ar;
            Issuer = await _db.Users.FindAsync(id);
        }

        public async Task<IActionResult> OnPost(int reqid, string email)
        {
            // do all these in a try-catch block
            SomeRequest = await _db.Requests.FindAsync(reqid);  // find the request
            Issuer = await _db.Users.FindAsync(email);  // find the Issuer
            SomeItem = await _db.StoreItems.FindAsync(SomeRequest.ItemId);  // find the item from the list

            // int Limit = (SomeRequest.QuantityRequested / SomeItem.QtyLeft) * 100;

            int diff = SomeItem.QtyLeft - SomeRequest.QuantityRequested;

            if (diff > 0)
            {
                SomeItem.QtyLeft -= SomeRequest.QuantityRequested;
                SomeRequest.IsServed = true;    //mark request as done
            }

            Issue = new ItemIssues();

            Issue.RequestId = SomeRequest.RequestId;
            Issue.QuantityIssued = SomeRequest.QuantityRequested;
            Issue.IssuedAt = DateTime.Now;
            Issue.Issuer = Issuer.ToString;

            await _db.Issues.AddAsync(Issue);   // add this issue

            await _db.SaveChangesAsync();   // save all changes to the database

            if (Issuer.IsAdmin) return RedirectToPage("AdminDashboard", Issuer.eMail);
            else return RedirectToPage("ElevatedUserDashboard", Issuer.eMail);
        }
    }
}