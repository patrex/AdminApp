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
    public class LoginModel : PageModel
    {
        private readonly AppDbContext _db;

        public LoginModel(AppDbContext db)
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
            var password = SomeUser.Password;
            var email = SomeUser.eMail;

            SomeUser = await _db.Users.FindAsync(email);


            if (SomeUser != null)
            {
                if (SomeUser.Password == password)
                {
                    if (SomeUser.IsAdmin) return RedirectToPage("AdminDashboard", email);     //admin login
                    if (SomeUser.IsElevatedUser) return RedirectToPage("ElevatedUserDashboard", email);     //elevated login

                    return RedirectToPage("UserDashboard", email); //normal login
                }   

                return RedirectToPage("Error");     //bad password
            }

            else return NotFound();
        }
    }
}