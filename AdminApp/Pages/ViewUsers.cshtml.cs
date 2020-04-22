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
    public class ViewUsersModel : PageModel
    {
        private readonly AppDbContext _db;

        public ViewUsersModel(AppDbContext db)
        {
            _db = db;
        }

        public IEnumerable<APINUser> Users { get; set; }

        public APINUser SomeUser { get; set; }

        public async Task OnGet()
        {
            Users = await _db.Users.ToListAsync();
        }

        public async Task<IActionResult> OnPostElevate(string id)
        {
            if (id != null)
            {
                SomeUser = await _db.Users.FindAsync(id);

                if (!SomeUser.IsElevatedUser && !SomeUser.IsAdmin) 
                {
                    SomeUser.IsElevatedUser = true;
                    await _db.SaveChangesAsync();

                    return RedirectToPage();
                } 
                else if (SomeUser.IsElevatedUser)
                {
                    SomeUser.IsAdmin = true;
                    SomeUser.IsElevatedUser = false;
                    await _db.SaveChangesAsync();

                    return RedirectToPage();
                } 
            }

            return RedirectToPage();
        }

        public async Task<IActionResult> OnPostDemote(string handler, string id)
        {
            SomeUser = await _db.Users.FindAsync(id);

            if (SomeUser.IsAdmin)
            {
                SomeUser.IsAdmin = false;
                SomeUser.IsElevatedUser = true;

                await _db.SaveChangesAsync();

                return RedirectToPage();
            }
            else if (SomeUser.IsElevatedUser)
            {
                SomeUser.IsElevatedUser = false;
                SomeUser.IsAdmin = false;

                await _db.SaveChangesAsync();

                return RedirectToPage();
            }

            return RedirectToPage();
        }

        public async Task<IActionResult> OnPostDelete(string handler, string id)
        {
            if(id != null)
            {
                SomeUser = await _db.Users.FindAsync(id);

                _db.Remove(SomeUser);
                await _db.SaveChangesAsync();

                return RedirectToPage();
            }
            else
            {
                return NotFound();
            }
            
        }
    }
}