﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AdminApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace AdminApp.Pages
{
    public class RequestItemModel : PageModel
    {
        private readonly AppDbContext _db;

        public RequestItemModel(AppDbContext db)
        {
            _db = db;
        }

        [BindProperty]
        public APINUser SomeUser { get; set; }

        [BindProperty]
        public IEnumerable<StoreItems> Items { get; set; }

        public async Task OnGet()
        {
            //Items = await _db.StoreItems.ToListAsync();
        }

        public async Task<IActionResult> OnPost()
        {
            //SomeUser = null;
            var password = SomeUser.Pswd;
            var email = SomeUser.eMail;

            SomeUser = await _db.Users.FindAsync(email);


            if (SomeUser != null)
            {
                if (SomeUser.Pswd == password)
                    return RedirectToPage("UserDashboard", email);

                return RedirectToPage("Error");
            }

            else return NotFound();
        }
    }
}