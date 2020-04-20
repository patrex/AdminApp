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
    public class ViewUsersModel : PageModel
    {
        private readonly AppDbContext _db;

        public ViewUsersModel(AppDbContext db)
        {
            _db = db;
        }

        public IEnumerable<APINUser> Users { get; set; }

        public async Task OnGet()
        {
            Users = await _db.Users.ToListAsync();
        }
    }
}