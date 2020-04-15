using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AdminApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AdminApp.Pages
{
    public class RequestItemModel : PageModel
    {
        private readonly AppDbContext _db;

        public RequestItemModel(AppDbContext db)
        {
            _db = db;
        }

        [BindProperty]
        public APINUser SomeUser { get; set; }

        [BindProperty]
        public IEnumerable<StoreItems> Items { get; set; }

        public void OnGet()
        {

        }
    }
}