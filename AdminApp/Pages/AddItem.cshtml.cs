using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AdminApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AdminApp.Pages
{
    public class AddItemModel : PageModel
    {
        private readonly AppDbContext _db;

        public AddItemModel(AppDbContext db)
        {
            _db = db;
        }

        [BindProperty]
        public StoreItems Item { get; set; }

        [BindProperty]
        public APINUser CurrentUser { get; set; }

        public async Task OnGet(string id, string handler)
        {
            if (handler != null) id = handler;
            CurrentUser = await _db.Users.FindAsync(id);
        }

        public async Task<IActionResult> OnPost(string id)
        {
            CurrentUser = await _db.Users.FindAsync(id);

            Item.QtyLeft = Item.QuantityAdded;
            Item.DateAdded = DateTime.Now;
            Item.AddedBy = CurrentUser.Fullname;

            await _db.StoreItems.AddAsync(Item);
            await _db.SaveChangesAsync();

            return RedirectToPage("AdminDashboard", CurrentUser.eMail);
        }
    }
}