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
    public class ReqItemModel : PageModel
    {
        private readonly AppDbContext _db;

        public ReqItemModel(AppDbContext db)
        {
            _db = db;
        }

        [BindProperty]
        public IEnumerable<StoreItems> StoreItems { get; set; }

        [BindProperty]
        public APINUser Requester { get; set; }

        [BindProperty]
        public Requests Request { get; set; }

        public async Task OnGet()
        {
            StoreItems = await _db.StoreItems.ToListAsync();
        }

        public async Task<IActionResult> OnPost()
        {
            if (ModelState.IsValid)
            {
                await _db.Requests.AddAsync(Request);

                return RedirectToPage("Index");
            }
            else
            {
                return Page();
            }
        }
        
    }
}