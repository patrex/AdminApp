using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AdminApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AdminApp.Pages
{
    public class UpdateItemModel : PageModel
    {
        private readonly AppDbContext _db;

        public UpdateItemModel(AppDbContext db)
        {
            _db = db;
        }

        [BindProperty]
        public StoreItems Item { get; set; }

        [BindProperty]
        public APINUser CurrentUser { get; set; }

        public async Task OnGet(int itemid, string id)  //id is for user email
        {
            CurrentUser = await _db.Users.FindAsync(id);

            if((itemid * 1) != 0) 
                Item = await _db.StoreItems.FindAsync(itemid);
        }

        public async Task<IActionResult> OnPost()
        {
            var someItem = await _db.StoreItems.FindAsync(Item.Id);
            var someUser = await _db.Users.FindAsync(CurrentUser.eMail);

            if(someItem != null)
            {
                someItem.QtyLeft += Item.QuantityAdded;
                someItem.DateAdded = DateTime.Now;
                someItem.AddedBy = someUser.Fullname;

                var i = await _db.SaveChangesAsync();

                return RedirectToPage("AdminDashboard", someUser.eMail);
            }
            else
            {
                return NotFound();
            }
        }
    }
}