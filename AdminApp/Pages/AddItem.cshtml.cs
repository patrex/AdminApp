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


        public void OnGet()
        {

        }

        public async Task<IActionResult> OnPost()
        {
            if (ModelState.IsValid)
            {
                Item.DateAdded = DateTime.Now;
                await _db.StoreItems.AddAsync(Item);
                await _db.SaveChangesAsync();

                return RedirectToPage("AdminDashbord");
            }
            else
            {
                return Page();
            }

        }
    }
}