using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using AdminApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AdminApp.Pages.ErrorPages
{
    public class ItemNotFoundModel : PageModel
    {
        private readonly AppDbContext _db;

        public ItemNotFoundModel(AppDbContext db)
        {
            _db = db;
        }

        [BindProperty]
        public StoreItems Item { get; set; }

        [BindProperty]
        public APINUser CurrentUser { get; set; }

        public async Task OnGet(string itemID)
        {
            Item = await _db.StoreItems.FindAsync(itemID);
        }
    }
}