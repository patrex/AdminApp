 using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AdminApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AdminApp.Pages
{
    public class AdminDashboardModel : PageModel
    {
        private readonly AppDbContext _db;

        public AdminDashboardModel(AppDbContext db)
        {
            _db = db;
        }

        public IEnumerable<APINUser> Users { get; set; }

        public IEnumerable<StoreItems> Items { get; set; }

        public IEnumerable<ItemIssues> Issues { get; set; }

        public IEnumerable<Requests> Requests { get; set; }

        public void OnGet()
        {

        }
    }
}