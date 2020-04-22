using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AdminApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AdminApp.Pages
{
    public class ElevatedUserDashboardModel : PageModel
    {
        private readonly AppDbContext _db;

        public ElevatedUserDashboardModel(AppDbContext db)
        {
            _db = db;
        }

        public APINUser ElevatedUser { get; set; }

        public async Task OnGet(string handler, string id)
        {
            if (id == null) id = handler;
            ElevatedUser = await _db.Users.FindAsync(id);
        }
    }
}