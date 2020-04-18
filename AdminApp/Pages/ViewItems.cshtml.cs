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

        public IEnumerable<StoreItems> Items { get; set; }
        public async Task OnGet()
        {
            Items = await _db.StoreItems.ToListAsync();
        }
    }
}