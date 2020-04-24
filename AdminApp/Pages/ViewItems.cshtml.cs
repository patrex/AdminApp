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
    public class ViewItemsModel : PageModel
    {
        private readonly AppDbContext _db;

        public ViewItemsModel(AppDbContext db)
        {
            _db = db;
        }

        public StoreItems Item { get; set; }

        public IEnumerable<StoreItems> Items { get; set; }
        public async Task OnGet()
        {
            Items = await _db.StoreItems.ToListAsync();
        }

        public async Task<IActionResult> OnPostIncrement(int id, string amt)
        {

            Item = await _db.StoreItems.FindAsync(id);
            Item.QtyLeft += 1;

            await _db.SaveChangesAsync();

            return RedirectToPage();
        }
    }
}