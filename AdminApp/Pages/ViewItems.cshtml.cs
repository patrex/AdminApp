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

        [BindProperty]
        public APINUser CurrentUser { get; set; }

        public IEnumerable<StoreItems> Items { get; set; }

        public async Task OnGet(string id)
        {
            Items = await _db.StoreItems.ToListAsync();
            CurrentUser = await _db.Users.FindAsync(id);    // 
        }
    }
}